using IncomeAndExpenses.Models;
using IncomeAndExpenses.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeAndExpenses.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        private string? _categoriesListPageTitle;
        private Category? _selectedCategory;

        public ObservableCollection<Category> Categories { get; }

        public Command LoadCategoriesCommand { get; }
        public Command NewCategoryCommand { get; }
        public Command RemoveCategoryCommand { protected set; get; }
        public Command<Category> CategoryTapCommand { get; }

        public CategoriesViewModel()
        {

            Categories = new ObservableCollection<Category>();

            LoadCategoriesCommand = new Command(async () => await ExecuteLoadCategoriesCommand());
            NewCategoryCommand = new Command(OnAddCategory);
            RemoveCategoryCommand = new Command<Category>(async (category) => await OnDeleteCategory(category));
            CategoryTapCommand = new Command<Category>(OnCategorySelected);
        }

        public string? CategoriesListPageTitle
        {
            get => _categoriesListPageTitle;
            set => SetProperty(ref _categoriesListPageTitle, value);
        }

        async Task ExecuteLoadCategoriesCommand()
        {
            string operation = _categoriesListPageTitle.Replace("ы", "");
            IsBusy = true;

            try
            {
                Categories.Clear();
                var categories = await CategoryDataStore.GetItemsAsyncByOperation(true, operation);
                foreach (var category in categories)
                {
                    Categories.Add(category);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedCategory = null;
        }

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set => SetProperty(ref _selectedCategory, value);
        }

        async void OnCategorySelected(Category category)
        {
            if (category == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(UpdateCategoryPage)}?{nameof(UpdateCategoryViewModel.CategoryId)}={category.Id_Category}");
        }


        private async void OnAddCategory(object obj)
        {
            string categoryOperation = Uri.EscapeDataString(_categoriesListPageTitle.Replace("ы", ""));
            await Shell.Current.GoToAsync($"{nameof(NewCategoryPage)}?{nameof(NewCategoryViewModel.CategoryOperation)}={categoryOperation}");
        }


        async Task OnDeleteCategory(Category category)
        {
            if (category == null)
                return;

            bool success = await CategoryDataStore.DeleteItemAsync(category.Id_Category);
            if (success)
            {
                Categories.Remove(category);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Невозможно удалить выбранную категорию", "OK");
            }
        }

    }
}
