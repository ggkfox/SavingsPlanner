using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Threading.Tasks;

namespace SavingsPlanner.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AssignAllIncomeAsync(ObservableCollection<T> expenses);
        Task<bool> AssignAllSavingsAsync(ObservableCollection<T> expenses);
        Task<bool> AssignAllExpensesAsync(ObservableCollection<T> expenses);

        Task<bool> AddIncomeAsync(T expense);
        Task<bool> AddSavingsAsync(T expense);
        Task<bool> AddMonthlyExpenseAsync(T expense);

        //Task<bool> UpdateExpenseAsync(T item);

        Task<bool> DeleteIncomeAsync(string id);
        Task<bool> DeleteSavingsAsync(string id);
        Task<bool> DeleteMonthlyExpenseAsync(string id);

        //Task<T> GetIncomeAsync(string id);
        //Task<T> GetSavingAsync(string id);
        //Task<T> GetMonthlyExpenseAsync(string id);

        Task<ObservableCollection<T>> GetIncomeSoursesAsync(bool forceRefresh = false);
        Task<ObservableCollection<T>> GetSavingsAsync(bool forceRefresh = false);
        Task<ObservableCollection<T>> GetMonthlyExpensesAsync(bool forceRefresh = false);

        int GetSumOfAllIncome();
        int GetSumOfAllSavings();
        int GetSumOfAllExpenses();
        int GetRemainder();
    }
}
