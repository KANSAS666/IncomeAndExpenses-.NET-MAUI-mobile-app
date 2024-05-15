using IncomeAndExpenses.Models;
using IncomeAndExpenses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeAndExpenses.ViewModels
{
    public class NewRecordViewModel : BaseViewModel
    {
        private string category;
        private string operation;
        private double sum = 0;
        private DateTime date = DateTime.Now;

        public Command AddRecordCommand { get; }
        public Command CancelRecordCommand { get; }

        public NewRecordViewModel()
        {

            AddRecordCommand = new Command(OnSave, ValidateSave);
            CancelRecordCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => AddRecordCommand.ChangeCanExecute();
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

        public double Sum
        {
            get => sum;
            set => SetProperty(ref sum, value);
        }

        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            //var recordList = await RecordDataStore.GetItemsAsync();
            var recordList = await RecordDataStore.GetItemsAsyncByOperation(false, "Все");
            int currentMaxId = -1;
            if (recordList?.Count() > 0)
            {
                currentMaxId = recordList.Max(x => x.Id_Record);
            }
            Record newRecord = new Record()
            {
                Id_Record = currentMaxId + 1,
                Category = Category,
                Operation = Operation,
                Sum = Sum,
                Date = Date
            };

            await RecordDataStore.AddItemAsync(newRecord);
            await Shell.Current.GoToAsync("..");
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(operation) && !String.IsNullOrWhiteSpace(category);
        }
    }
}

