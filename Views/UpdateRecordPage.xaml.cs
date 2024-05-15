using IncomeAndExpenses.Models;
using IncomeAndExpenses.ViewModels;

namespace IncomeAndExpenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateRecordPage : ContentPage
	{
		private UpdateRecordViewModel _viewModel;

        
       // private IEnumerable<Expense> ExpenseCategories;
        private IEnumerable<Category> Categories;
        private string defaultCetegory;



        public UpdateRecordPage()
		{
			InitializeComponent();
			BindingContext = _viewModel = new UpdateRecordViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            defaultCetegory = _viewModel.Category;
            LoadCategories(_viewModel.Operation);
        }


        private async void LoadCategories(string operation)
        {
            if (operation == null)
                return;

            Categories = await _viewModel.CategoryDataStore.GetItemsAsyncByOperation(true, operation);
            List<string> CategoriesTitles = new List<string>();
                

            foreach (var category in Categories)
            {
                CategoriesTitles.Add(category.CategoryName);
            }

            PickerCategory.ItemsSource = CategoriesTitles;

            PickerCategory.SelectedItem = defaultCetegory;
        }

        private async void pickerCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCategory = PickerCategory.SelectedItem?.ToString();
            _viewModel.Category = selectedCategory;          
        }

        private void DatePickerDate_onDateSelected(object sender, DateChangedEventArgs e)
        {
            _viewModel.Date = e.NewDate;
        }
    }
}