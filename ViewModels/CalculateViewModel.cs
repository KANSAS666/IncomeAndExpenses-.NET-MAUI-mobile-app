using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomeAndExpenses.Models;
using IncomeAndExpenses.Services;


namespace IncomeAndExpenses.ViewModels
{
    [QueryProperty(nameof(Operation), nameof(Operation))]
    public class CalculateViewModel : BaseViewModel
    {
        public Command CalculateSumCommand { get; }
        public Command CancelCalculateCommand { get; }

        private string operation;
        private string category;
        private string period;
        private DateTime startDate = DateTime.Now;
        private DateTime endDate = DateTime.Now;

        public CalculateViewModel()
        {
            CalculateSumCommand = new Command(onCalculate);
            CancelCalculateCommand = new Command(onCancel);
        }
            
        public string Operation
        {
            get => operation;
            set => SetProperty(ref operation, value);
        }

        public string Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }

        public string Period
        {
            get => period;
            set => SetProperty(ref period, value);
        }

        public DateTime StartDate
        {
            get => startDate;
            set => SetProperty(ref startDate, value);
        }

        public DateTime EndDate
        {
            get => endDate;
            set => SetProperty(ref endDate, value);
        }

        private async void onCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void onCalculate()
        {         
            if (Period == "За день")
            {
                StartDate = DateTime.Now.AddDays(-1);
            }
            else if (Period == "За неделю")
            {
                StartDate = DateTime.Now.AddDays(-7);
            }
            else if (Period == "За месяц")
            {
                StartDate = DateTime.Now.AddMonths(-1);
            }

            double totalSum = await RecordDataStore.CalculateTotalSum(Operation, Category, StartDate, EndDate);

            string displayOperation = Operation + "ов";

            await Shell.Current.DisplayAlert("Расчет общей суммы", $"Общая сумма {displayOperation}: {totalSum}", "ОК");
        }
    }
}
