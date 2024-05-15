using IncomeAndExpenses.ViewModels;

namespace IncomeAndExpenses.Views;

public partial class UpdateCategoryPage : ContentPage
{
	private UpdateCategoryViewModel _viewModel;
    public UpdateCategoryPage()
	{
		InitializeComponent();
		BindingContext = _viewModel = new UpdateCategoryViewModel();
	}
}