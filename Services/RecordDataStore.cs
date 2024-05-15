using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncomeAndExpenses.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui.Storage;
using Microsoft.Maui.Media;
using SQLite;
using System.Diagnostics;


namespace IncomeAndExpenses.Services
{
    public class RecordDataStore : IDataStoreRecords<Record>
    {
        List<Record> records;
        List<Record> cachedAddRecords;
        List<Record> cachedUpdateRecords;
        List<int> cachedDeleteRecords;
        int recordsDatabaseId;
        Random random = new Random();
        //Подключение БД
        FirebaseClient db = new FirebaseClient(Constants.FirebaseUrl);

        SQLiteAsyncConnection localDb;
        public RecordDataStore()
        {
            records = new List<Record>();
            cachedAddRecords = new List<Record>();
            cachedUpdateRecords = new List<Record>();
            cachedDeleteRecords = new List<int>();

            recordsDatabaseId = Preferences.Default.Get("recordsDatabaseId", -1);
            if (recordsDatabaseId == -1)
            {
                recordsDatabaseId = random.Next();
                Preferences.Default.Set("recordsDatabaseId", recordsDatabaseId);
                Debug.WriteLine("recordsDatabaseId не найден: " + recordsDatabaseId);
            }
            else
            {
                Debug.WriteLine("recordsDatabaseId найден: " + recordsDatabaseId);
            }

            InitializeLocalDatabase();
        }

        private async void InitializeLocalDatabase()
        {
            localDb = new SQLiteAsyncConnection(Constants.LocalDbPath, Constants.Flags);
            await localDb.CreateTableAsync<Record>();
        }

        public async Task<bool> AddItemAsync(Record item)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                await db
              .Child("Records_" + recordsDatabaseId)
              .PostAsync(item);
            }
            else
            {
                cachedAddRecords.Add(item);
                await localDb.InsertAsync(item);
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Record item)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var recordToUpdate = (await db
                .Child("Records_" + recordsDatabaseId)
                .OnceAsync<Record>()).Where(x => x.Object.Id_Record == item.Id_Record).FirstOrDefault();

                if (recordToUpdate != null)
                {
                    await db
                        .Child("Records_" + recordsDatabaseId)
                        .Child(recordToUpdate.Key)
                        .PutAsync(item);
                }
            }
            else
            {
                cachedUpdateRecords.Add(item);
                await localDb.UpdateAsync(item);
            }
                

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var recordToDelete = (await db
                .Child("Records_" + recordsDatabaseId)
                .OnceAsync<Record>()).Where(x => x.Object.Id_Record == id).FirstOrDefault();

                if (recordToDelete != null)
                {
                    await db
                        .Child("Records_" + recordsDatabaseId)
                        .Child(recordToDelete.Key)
                        .DeleteAsync();
                }
            }
            else
            {
                cachedDeleteRecords.Add(id);
                await localDb.DeleteAsync<Record>(id);
            }
                
            return await Task.FromResult(true);
        }

        public async Task<Record> GetItemAsync(int id)
        {
            return await Task.FromResult(records.FirstOrDefault(s => s.Id_Record == id));
        }

        public async Task<IEnumerable<Record>> GetItemsAsync(bool forceRefresh = false)
        {
            records = (await db
              .Child("Records_" + recordsDatabaseId)
              .OnceAsync<Record>()).Select(record => new Record
              {
                  Id_Record = record.Object.Id_Record,
                  Date = record.Object.Date,
                  Sum = record.Object.Sum,
                  Operation = record.Object.Operation,
                  Category = record.Object.Category
              }).ToList();

            return records;
        }

        public async Task<IEnumerable<Record>> GetItemsAsyncByOperation(bool forceRefresh = false, string operation = null)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                var localRecords = await localDb.Table<Record>().ToListAsync();
                records.Clear();
                if (operation == "Все")
                {
                    foreach(var record in localRecords)
                    {
                        records.Add(record);
                    }
                }
                else
                {
                    string replaceOperation = operation.Replace("ы", "");
                    foreach(var record in localRecords)
                    {
                        if (record.Operation == replaceOperation)
                        {
                            records.Add(record);
                        }
                    }
                }
            }

            else
            {

                if (cachedAddRecords.Count != 0)
                {
                    var recordsToPost = cachedAddRecords
                        .Where(record => !cachedDeleteRecords.Contains(record.Id_Record))
                        .ToList();

                    foreach (var cacheItem in recordsToPost)
                    {
                        await db.Child("Records_" + recordsDatabaseId).PostAsync(cacheItem);
                    }
                    cachedAddRecords.Clear();
                }

                if (cachedDeleteRecords.Count != 0)
                {
                    foreach (int id in cachedDeleteRecords)
                    {
                        await DeleteItemAsync(id);
                    }
                    cachedDeleteRecords.Clear();
                }

                if (cachedUpdateRecords.Count != 0)
                {
                    foreach (var cacheItem in cachedUpdateRecords)
                    {
                        await UpdateItemAsync(cacheItem);
                    }
                    cachedUpdateRecords.Clear();
                }



                if (operation == "Все")
                {
                    records = (await db
                      .Child("Records_" + recordsDatabaseId)
                      .OnceAsync<Record>()).Select(record => new Record
                      {
                          Id_Record = record.Object.Id_Record,
                          Date = record.Object.Date,
                          Sum = record.Object.Sum,
                          Operation = record.Object.Operation,
                          Category = record.Object.Category
                      }).ToList();
                }
                else
                {
                    string replaceOperation = operation.Replace("ы", "");

                    records = (await db
                      .Child("Records_" + recordsDatabaseId)
                      .OnceAsync<Record>()).Select(record => new Record
                      {
                          Id_Record = record.Object.Id_Record,
                          Date = record.Object.Date,
                          Sum = record.Object.Sum,
                          Operation = record.Object.Operation,
                          Category = record.Object.Category
                      }).Where(record => record.Operation == replaceOperation).ToList();
                }

                await localDb.DeleteAllAsync<Record>();
                foreach (var record in records)
                {
                    await localDb.InsertOrReplaceAsync(record);
                }
            }

            return records;
        }

        public async Task<double> CalculateTotalSum(string operation, string category, DateTime startDate, DateTime endDate)
        {
            double totalSum = 0;
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                IEnumerable<Record> recordsInRange;

                if (category == "Все")
                {
                    recordsInRange = (await db
                        .Child("Records_" + recordsDatabaseId)
                        .OnceAsync<Record>())
                        .Select(record => record.Object)
                        .Where(record => record.Operation == operation &&
                                         record.Date >= startDate &&
                                         record.Date <= endDate);
                }
                else
                {
                    recordsInRange = (await db
                        .Child("Records_" + recordsDatabaseId)
                        .OnceAsync<Record>())
                        .Select(record => record.Object)
                        .Where(record => record.Operation == operation &&
                                         record.Category == category &&
                                         record.Date >= startDate &&
                                         record.Date <= endDate);
                }

                totalSum = recordsInRange.Sum(record => record.Sum);

            }
            else
            {
                var localRecords = await localDb.Table<Record>().ToListAsync();

                if (category == "Все")
                {
                    totalSum = localRecords
                        .Where(record => record.Operation == operation &&
                                         record.Date >= startDate &&
                                         record.Date <= endDate)
                        .Sum(record => record.Sum);
                }
                else
                {
                    totalSum = localRecords
                        .Where(record => record.Operation == operation &&
                                         record.Category == category &&
                                         record.Date >= startDate &&
                                         record.Date <= endDate)
                        .Sum(record => record.Sum);
                }
            }

            return totalSum;

        }

        public async Task UpdateCategoryNameInRecordsLocal(string oldCategoryName, string newCategoryName)
        {
            var recordsToUpdate = await localDb.Table<Record>().Where(record => record.Category == oldCategoryName).ToListAsync();

            foreach (var record in recordsToUpdate)
            {
                record.Category = newCategoryName;
                await localDb.UpdateAsync(record);
            }
        }


    }
}

