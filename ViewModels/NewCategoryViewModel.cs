using IncomeAndExpenses.Models;
using IncomeAndExpenses.ViewModels;
using IncomeAndExpenses.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeAndExpenses.ViewModels
{
    [QueryProperty(nameof(CategoryOperation), nameof(CategoryOperation))]
    public class NewCategoryViewModel : BaseViewModel
    {
        private string _categoryName;
        private string _categoryOperation;

        public Command AddCategoryCommand { get; }
        public Command CancelCategoryCommand { get; }

        public NewCategoryViewModel()
        {

            AddCategoryCommand = new Command(OnSave, ValidateSave);
            CancelCategoryCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => AddCategoryCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_categoryName);
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

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            var categoriesList = await CategoryDataStore.GetItemsAsync();
            int currentMaxId = -1;
            if (categoriesList?.Count() > 0)
            {
                currentMaxId = categoriesList.Max(x => x.Id_Category);
            }
            Category newCategory = new Category()
            {
                Id_Category = currentMaxId + 1,
                CategoryName = CategoryName,
                CategoryOperation = CategoryOperation
            };

            await CategoryDataStore.AddItemAsync(newCategory);
            await Shell.Current.GoToAsync("..");
        }
    }
}

