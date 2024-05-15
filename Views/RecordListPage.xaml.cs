using IncomeAndExpenses.ViewModels;
using IncomeAndExpenses.Models;

namespace IncomeAndExpenses.Views
{ 

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecordListPage : ContentPage
	{
    
		private RecordViewModel _viewModel;
		private bool isSlidingPanelShown = false;

        public RecordListPage()
		{
			InitializeComponent();
			BindingContext = _viewModel = new RecordViewModel();

        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_viewModel.OnAppearing();

            HideSlidingPanel();

        }

		private void OperationPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedOperation = OperationPicker.SelectedItem.ToString();
			_viewModel.Operation = selectedOperation;
			RecordsRefreshView.IsRefreshing = true;
		}

		private void CalculateMenu_OnSwiped(object sender, SwipedEventArgs e)
		{
			switch (e.Direction)
			{
                case SwipeDirection.Down:
                    SwitchSlidingPanel();
                    break;
            }
		}

        private async void OnCalcButtonClicked(object sender, EventArgs e)
        {
            SwitchSlidingPanel();
            await AnimateCalcButton();   
        }


        private async Task AnimateCalcButton()
        {
            CalcButton.ScaleTo(0.9, 125);
            await CalcButton.TranslateTo(0, -5, 125);

            CalcButton.ScaleTo(1, 125);
            await CalcButton.TranslateTo(0, 5, 125);

        }


        private async void HideSlidingPanel()
        {
            
            while (Height == -1)
            {
                await Task.Delay(200);
                SlidingPanel.TranslationY = Height;
            }
            SlidingPanel.TranslationY = Height;

            AddRecordButton.Margin = new Thickness(0, 0, 10, 10);
            CalcButton.Margin = new Thickness(0, 0, 10, 95);
            isSlidingPanelShown = false;
            SlidingPanel.IsVisible = true;
        }

        private void SwitchSlidingPanel()
        {
            uint animationTime = 250;

            if (isSlidingPanelShown)
            {
                SlidingPanel.TranslateTo(0, Height, animationTime, Easing.SinInOut);
                AddRecordButton.Margin = new Thickness(0, 0, 10, 10);
                CalcButton.Margin = new Thickness(0, 0, 10, 95);
            }
            else
            {
                SlidingPanel.TranslateTo(0, Height - CalculateMenu.Height - CalculateMenu.Height - 15, animationTime, Easing.SpringOut);
                AddRecordButton.Margin = new Thickness(0, 0, 10, 90);
                CalcButton.Margin = new Thickness(0, 0, 10, 175);
            }

            isSlidingPanelShown = !isSlidingPanelShown;

        }

    }
}