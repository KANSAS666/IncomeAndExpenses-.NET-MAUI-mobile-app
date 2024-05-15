using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IncomeAndExpenses.Services
{
    public interface IDataStoreRecords<T> : IDataStore<T>
    {
        Task<double> CalculateTotalSum(string operation, string category, DateTime startDate, DateTime endDate);
    }
}
