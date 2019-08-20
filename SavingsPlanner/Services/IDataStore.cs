using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SavingsPlanner.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddExpenseAsync(T item);
        Task<bool> UpdateExpenseAsync(T item);
        Task<bool> DeleteExpenseAsync(string id);
        Task<T> GetExpenseAsync(string id);
        Task<IEnumerable<T>> GetExpensesAsync(bool forceRefresh = false);
    }
}
