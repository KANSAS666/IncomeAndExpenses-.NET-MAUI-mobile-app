using IncomeAndExpenses.Models;
using IncomeAndExpenses.Services;
using IncomeAndExpenses.ViewModels;

namespace IncomeAndExpenses.Views
{ 
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class NewRecordPage : ContentPage
{
	private NewRecordViewModel _viewModel;

    private IEnumerable<Category> Categories;

    public NewRecordPage()
	{
		InitializeComponent();
		BindingContext = _viewModel = new NewRecordViewModel();
    }

        private async void pickerOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PickerOperation.SelectedItem == null)
                return;

            string operation = PickerOperation.SelectedItem.ToString();

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

        private void pickerCategory_SelectedIndexChanged(object sender, EventArgs e)
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