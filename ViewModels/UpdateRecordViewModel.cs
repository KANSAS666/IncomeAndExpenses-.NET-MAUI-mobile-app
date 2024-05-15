using IncomeAndExpenses.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IncomeAndExpenses.ViewModels
{
    [QueryProperty(nameof(RecordId), nameof(RecordId))]
    public class UpdateRecordViewModel : BaseViewModel
    {
        private int recordId;
        private string category;
        private string operation;
        private double sum;
        private DateTime date;

        public Command UpdateRecordCommand { get; }
        public Command CancelUpdateRecordCommand { get; }

        public UpdateRecordViewModel()
        {
            UpdateRecordCommand = new Command(async () => await OnUpdate());
            CancelUpdateRecordCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => CancelUpdateRecordCommand.ChangeCanExecute();
        }

        public int RecordId
        {
            get
            {
                return recordId;
            }
            set
            {
                recordId = value;
                LoadRecordId(value);
            }
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


        public async void LoadRecordId(int recordId)
        {
            try
            {
                var record = await RecordDataStore.GetItemAsync(recordId);
                Operation = record.Operation;
                Category = record.Category;
                Sum = record.Sum;
                Date = record.Date;              
            }
            catch (Exception)
            {
                Debug.WriteLine("Ошибка в загрузке записи");
            }
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async Task OnUpdate()
        {
            try
            {
                var recordToUpdate = new Record
                {
                    Id_Record = RecordId,
                    Operation = Operation,
                    Category = Category,
                    Sum = Sum,
                    Date = Date
                };

                await RecordDataStore.UpdateItemAsync(recordToUpdate);
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка при обновлении выбранной записи: {ex.Message}");
            }
        }
    }
}
