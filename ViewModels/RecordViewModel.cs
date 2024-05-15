using IncomeAndExpenses.ViewModels;
using System;
using IncomeAndExpenses.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using System.Collections.ObjectModel;
using System.Diagnostics;
using IncomeAndExpenses.Services;
using IncomeAndExpenses.Views;
using Microsoft.Maui.ApplicationModel.Communication;


namespace IncomeAndExpenses.ViewModels
{
    public class RecordViewModel : BaseViewModel
    {
        private Record selectedRecord;
        private string operation = "Все";       

        public ObservableCollection<Record> Records { get; }

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Record> RecordTapped { get; }
        public Command RemoveRecordCommand { protected set; get; }
        public Command ExpenseCalculateCommand { get; }
        public Command IncomeCalculateCommand { get; }


        public RecordViewModel()
        {

            Records = new ObservableCollection<Record>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            RecordTapped = new Command<Record>(OnRecordSelected);
            AddItemCommand = new Command(OnAddItem);
            RemoveRecordCommand = new Command<Record>(async (record) => await OnDeleteRecord(record));
            ExpenseCalculateCommand = new Command(onExpenseCalculate);
            IncomeCalculateCommand = new Command(onIncomeCalculate);
        }

        public string Operation
        {
            get => operation;
            set => SetProperty(ref operation, value);
        }

       
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Records.Clear();

                var items = await RecordDataStore.GetItemsAsyncByOperation(true, Operation);
                foreach (var item in items)
                {
                    Records.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedRecord = null;
        }

        public Record SelectedRecord
        {
            get => selectedRecord;
            set
            {
                SetProperty(ref selectedRecord, value);
                OnRecordSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {

            await Shell.Current.GoToAsync(nameof(NewRecordPage));
        }


        async Task OnDeleteRecord(Record record)
        {
            if (record == null)
                return;

            bool success = await RecordDataStore.DeleteItemAsync(record.Id_Record);
            if (success)
            {
                Records.Remove(record);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Невозможно удалить запись", "OK");
            }
        }

        async void OnRecordSelected(Record record)
        {
            if (record == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(UpdateRecordPage)}?{nameof(UpdateRecordViewModel.RecordId)}={record.Id_Record}");
        }

        private async void onExpenseCalculate()
        {
            string expenseOperation = Uri.EscapeDataString("Расход");
            await Shell.Current.GoToAsync($"{nameof(CalculatePage)}?{nameof(CalculateViewModel.Operation)}={expenseOperation}");
        }

        private async void onIncomeCalculate()
        {
            string incomeOperation = Uri.EscapeDataString("Доход");
            await Shell.Current.GoToAsync($"{nameof(CalculatePage)}?{nameof(CalculateViewModel.Operation)}={incomeOperation}");
        }

    }
}

