using System.Linq;
using System.Threading.Tasks;
using IncomeAndExpenses.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui.Storage;
using SQLite;
using System.Diagnostics;
using System.Collections.Generic;

namespace IncomeAndExpenses.Services
{
    public class CategoryDataStore : IDataStore<Category>
    {

        List<Category> categories;
        List<Category> addedCachedCategories;
        List<Category> updatedCachedCategories;
        List<int> deletedCachedCategories;
        int categoriesDatabaseId;
        int recordsDatabaseId;


        Random random = new Random();
        //Подключение БД
        FirebaseClient firebaseDatabase;

        SQLiteAsyncConnection localDb;

        public CategoryDataStore()
        {
            categories = new List<Category>();
            addedCachedCategories = new List<Category>();
            updatedCachedCategories = new List<Category>();
            deletedCachedCategories = new List<int>();

            categoriesDatabaseId = Preferences.Default.Get("categoriesDatabaseId", -1);
            if (categoriesDatabaseId == -1)
            {
                categoriesDatabaseId = random.Next();
                Preferences.Default.Set("categoriesDatabaseId", categoriesDatabaseId);
            }

            int _recordsDatabaseId = Preferences.Default.Get("recordsDatabaseId", -1);
            if (_recordsDatabaseId != -1)
            {
                recordsDatabaseId = _recordsDatabaseId;
            }

            firebaseDatabase = new FirebaseClient(Constants.FirebaseUrl);
            InitializeLocalDatabase();
        }

        //Add category
        public async Task<bool> AddItemAsync(Category category)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                await firebaseDatabase.Child("Categories_" + categoriesDatabaseId).PostAsync(category);
            }
            else
            {
                addedCachedCategories.Add(category);
                await localDb.InsertAsync(category);
            }

            return await Task.FromResult(true);
        }

        //Update category
        public async Task<bool> UpdateItemAsync(Category category)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var categoryToUpdate = (await firebaseDatabase
                .Child("Categories_" + categoriesDatabaseId)
                .OnceAsync<Category>()).Where(x => x.Object.Id_Category == category.Id_Category).FirstOrDefault();

                if (categoryToUpdate != null)
                {
                    await firebaseDatabase
                        .Child("Categories_" + categoriesDatabaseId)
                        .Child(categoryToUpdate.Key)
                        .PutAsync(category);

                    var recordsToUpdate = (await firebaseDatabase
                    .Child("Records_" + recordsDatabaseId)
                    .OnceAsync<Record>()).Where(x => x.Object.Category == categoryToUpdate.Object.CategoryName && x.Object.Operation == categoryToUpdate.Object.CategoryOperation).ToList();

                    if (recordsToUpdate.Count != 0)
                    {                      
                        foreach (var record in recordsToUpdate)
                        {
                            record.Object.Category = category.CategoryName;
                            await firebaseDatabase
                                .Child("Records_" + recordsDatabaseId)
                                .Child(record.Key)
                                .PutAsync(record.Object);
                        }
                    }
                }
            }
            else
            {
                updatedCachedCategories.Add(category);

                var oldCategory = categories.FirstOrDefault(c => c.Id_Category == category.Id_Category);
                if (oldCategory != null)
                {
                    var oldCategoryName = oldCategory.CategoryName;
                    RecordDataStore recordDataStore = new RecordDataStore();
                    await recordDataStore.UpdateCategoryNameInRecordsLocal(oldCategoryName, category.CategoryName);

                }
                
                await localDb.InsertOrReplaceAsync(category);
                
            }
            return await Task.FromResult(true);
        }

        //Delete category
        public async Task<bool> DeleteItemAsync(int id)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var categoryToDelete = (await firebaseDatabase
                .Child("Categories_" + categoriesDatabaseId)
                .OnceAsync<Category>()).Where(x => x.Object.Id_Category == id).FirstOrDefault();

                if (categoryToDelete != null)
                {
                    await firebaseDatabase
                        .Child("Categories_" + categoriesDatabaseId)
                        .Child(categoryToDelete.Key)
                        .DeleteAsync();

                    var recordsToDelete = (await firebaseDatabase
                    .Child("Records_" + recordsDatabaseId)
                    .OnceAsync<Record>()).Where(x => x.Object.Category == categoryToDelete.Object.CategoryName && x.Object.Operation == categoryToDelete.Object.CategoryOperation).ToList();

                    if (recordsToDelete.Count != 0)
                    {
                        foreach (var item in recordsToDelete)
                        {
                            await firebaseDatabase
                                .Child("Records_" + recordsDatabaseId)
                                .Child(item.Key)
                                .DeleteAsync();
                        }
                    }

                }
            }
            else
            {
                deletedCachedCategories.Add(id);
                await localDb.DeleteAsync<Category>(id);
            }


            return await Task.FromResult(true);
        }

        //Get category
        public async Task<Category> GetItemAsync(int id)
        {
            return await Task.FromResult(categories.FirstOrDefault(s => s.Id_Category == id));
        }

        //Get categories
        public async Task<IEnumerable<Category>> GetItemsAsync(bool forceRefresh = false)
        {

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                if (addedCachedCategories.Count != 0)
                {
                    var categoriesToPost = addedCachedCategories
                        .Where(category => !deletedCachedCategories.Contains(category.Id_Category))
                        .ToList();

                    foreach (var cacheItem in categoriesToPost)
                    {
                        await firebaseDatabase.Child("Categories_" + categoriesDatabaseId).PostAsync(cacheItem);
                    }
                    addedCachedCategories.Clear();
                }

                if (deletedCachedCategories.Count != 0)
                {
                    foreach (int id in deletedCachedCategories)
                    {
                        await DeleteItemAsync(id);
                    }
                    deletedCachedCategories.Clear();
                }

                if (updatedCachedCategories.Count != 0)
                {
                    foreach (var cacheItemId in updatedCachedCategories)
                    {
                        await UpdateItemAsync(cacheItemId);
                    }
                    updatedCachedCategories.Clear();
                }

               categories = (await firebaseDatabase
              .Child("Categories_" + categoriesDatabaseId)
              .OnceAsync<Category>()).Select(category => new Category
              {
                  Id_Category = category.Object.Id_Category,
                  CategoryName = category.Object.CategoryName,
                  CategoryOperation = category.Object.CategoryOperation
              }).ToList();

                await localDb.DeleteAllAsync<Category>();

                foreach (var category in categories)
                {
                    await localDb.InsertOrReplaceAsync(category);
                }
                
            }
            else
            {
                var localCategories = await localDb.Table<Category>().ToListAsync();
                categories.Clear();
                foreach (var item in localCategories)
                {
                    categories.Add(item);
                }

            }

            return categories;
        }

        //Get categories by operation
        public async Task<IEnumerable<Category>> GetItemsAsyncByOperation(bool forceRefresh = false, string operation = null)
        {

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                if (addedCachedCategories.Count != 0)
                {
                    var categoriesToPost = addedCachedCategories
                        .Where(category => !deletedCachedCategories.Contains(category.Id_Category))
                        .ToList();

                    foreach (var cacheItem in categoriesToPost)
                    {
                        await firebaseDatabase.Child("Categories_" + categoriesDatabaseId).PostAsync(cacheItem);
                    }
                    addedCachedCategories.Clear();
                }

                if (deletedCachedCategories.Count != 0)
                {
                    foreach (int id in deletedCachedCategories)
                    {
                        await DeleteItemAsync(id);
                    }
                    deletedCachedCategories.Clear();
                }

                if (updatedCachedCategories.Count != 0)
                {
                    foreach (var cacheItemId in updatedCachedCategories)
                    {
                        await UpdateItemAsync(cacheItemId);
                    }
                    updatedCachedCategories.Clear();
                }
 
                await localDb.DeleteAllAsync<Category>();

                List<Category> allLocalCategories = (List<Category>)await GetItemsAsync();
                categories = allLocalCategories.Where(category => category.CategoryOperation == operation).ToList();

                foreach (var category in allLocalCategories)
                {
                    await localDb.InsertOrReplaceAsync(category);
                }

            }

            else
            {
                var localCategories = await localDb.Table<Category>().ToListAsync();
                categories.Clear();
                foreach (var item in localCategories)
                {
                    if (item.CategoryOperation == operation)
                    {
                        categories.Add(item);
                    }       
                }
            }

            return categories;
        }

        //Initialize SQLite database
        private async void InitializeLocalDatabase()
        {
            localDb = new SQLiteAsyncConnection(Constants.LocalDbPath, Constants.Flags);
            await localDb.CreateTableAsync<Category>();
        }

    }
}
