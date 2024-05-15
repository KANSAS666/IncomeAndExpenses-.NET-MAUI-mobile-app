using IncomeAndExpenses.ViewModels;
using IncomeAndExpenses.Models;

namespace IncomeAndExpenses.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalculatePage : ContentPage
	{

		private CalculateViewModel _viewModel;

        //private IEnumerable<Expense> ExpenseCategories;
        private IEnumerable<Category> Categories;

        public CalculatePage()
		{
			InitializeComponent();
			BindingContext = _viewModel = new CalculateViewModel();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
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

            if (CategoriesTitles.Count > 0)
            {
                PickerCategory.SelectedIndex = 0;
            }

        }

        private async void pickerCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCategory = PickerCategory.SelectedItem?.ToString();
            _viewModel.Category = selectedCategory;          
        }

        private async void PeriodPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPeriod = PeriodPicker.SelectedItem?.ToString();
            if (selectedPeriod == "”казать свой период")
            {
                CustomDatePeriod.IsVisible = true;
            }
            else
            {
                CustomDatePeriod.IsVisible = false;
                _viewModel.Period = selectedPeriod;
            }         
        }

        private void DatePickerDate_onStartDateSelected(object sender, DateChangedEventArgs e)
        {
            _viewModel.StartDate = e.NewDate;
        }

        private void DatePickerDate_onEndDateSelected(object sender, DateChangedEventArgs e)
        {
            _viewModel.EndDate = e.NewDate;
        }

    }
}