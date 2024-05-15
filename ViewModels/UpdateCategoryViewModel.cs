using IncomeAndExpenses.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IncomeAndExpenses.ViewModels
{
    [QueryProperty(nameof(CategoryId), nameof(CategoryId))]
    public class UpdateCategoryViewModel : BaseViewModel
    {
        private int _categoryId;
        private string _categoryName;
        private string _categoryOperation;

        public Command UpdateCategoryCommand { get; }
        public Command CancelUpdateCategoryCommand { get; }

        public UpdateCategoryViewModel()
        {
            UpdateCategoryCommand = new Command(async () => await OnUpdate());
            CancelUpdateCategoryCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => CancelUpdateCategoryCommand.ChangeCanExecute();
        }

        public string CategoryName
        {
            get => _categoryName;
            set => SetProperty(ref _categoryName, value);
        }

        public string CategoryOperation
        {
            get => _categoryOperation;
            set => SetProperty(ref _categoryOperation, value);
        }

        public int CategoryId
        {
            get
            {
                return _categoryId;
            }
            set
            {
                _categoryId = value;
                LoadCategoryId(value);
            }
        }

        public async void LoadCategoryId(int categoryId)
        {
            try
            {
                var category = await CategoryDataStore.GetItemAsync(categoryId);

                CategoryName = category.CategoryName;
                CategoryOperation = category.CategoryOperation;
            }
            catch (Exception)
            {
                Debug.WriteLine("Ошибка в загрузке категории");
            }
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async Task OnUpdate()
        {
            try
            {
                var categoryToUpdate = new Category
                {
                    Id_Category = CategoryId,
                    CategoryName = CategoryName,
                    CategoryOperation = CategoryOperation
                };

                await CategoryDataStore.UpdateItemAsync(categoryToUpdate);
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка при обновлении выбранной категории: {ex.Message}");
            }
        }
    }
}
