using IncomeAndExpenses.ViewModels;

namespace IncomeAndExpenses.Views;

public partial class CategoriesListPage : ContentPage
{
    private CategoriesViewModel _viewModel;
    public CategoriesListPage()
	{
		InitializeComponent();
		BindingContext = _viewModel = new CategoriesViewModel();
        
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var categoriesListPageTitle = ((ShellContent)Parent).Title;
        _viewModel.CategoriesListPageTitle = categoriesListPageTitle;
        _viewModel.OnAppearing();
        SetEmptyView(categoriesListPageTitle);
    }

    private void SetEmptyView(string categoriesListPageTitle)
    {
        if (categoriesListPageTitle == "Расходы")
            CategoriesListView.EmptyView = "Список расходов пуст";
        else
            CategoriesListView.EmptyView = "Список Доходов пуст";
    }

}