using IncomeAndExpenses.ViewModels;

namespace IncomeAndExpenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCategoryPage : ContentPage
    {
        private NewCategoryViewModel _viewModel;
        public NewCategoryPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new NewCategoryViewModel();
        }
    }
}

