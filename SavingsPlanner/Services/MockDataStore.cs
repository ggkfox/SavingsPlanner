using System;
//using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using SavingsPlanner.Models;

namespace SavingsPlanner.Services
{
    public class MockDataStore : IDataStore<Expense>
    {
        ObservableCollection<Expense> IncomeSources;
        ObservableCollection<Expense> Savings;
        ObservableCollection<Expense> MonthlyExpenses;

        public MockDataStore()
        {
            IncomeSources = new ObservableCollection<Expense>();
            Savings = new ObservableCollection<Expense>();
            MonthlyExpenses = new ObservableCollection<Expense>();
        }

        //-----------Assign Function-------------
        public async Task<bool> AssignIncomeAsync(ObservableCollection<Expense> expenses)
        {
            IncomeSources = expenses;
            return await Task.FromResult(true);
        }
        public async Task<bool> AssignSavingsAsync(ObservableCollection<Expense> expenses)
        {
            Savings = expenses;
            return await Task.FromResult(true);
        }
        public async Task<bool> AssignExpensesAsync(ObservableCollection<Expense> expenses)
        {
            MonthlyExpenses = expenses;
            return await Task.FromResult(true);
        }

        //-----------Add Functions-------------
        public async Task<bool> AddIncomeAsync(Expense expense)
        {
            IncomeSources.Add(expense);
            return await Task.FromResult(true);
        }

        public async Task<bool> AddSavingsAsync(Expense expense)
        {
            Savings.Add(expense);
            return await Task.FromResult(true);
        }

        public async Task<bool> AddMonthlyExpenseAsync(Expense expense)
        {
            MonthlyExpenses.Add(expense);
            return await Task.FromResult(true);
        }


        //-----------Update Functions-------------
        //public async Task<bool> UpdateExpenseAsync(Expense Expense)
        //{
        //    var oldExpense = Expenses.Where((Expense arg) => arg.Id == Expense.Id).FirstOrDefault();
        //    Expenses.Remove(oldExpense);
        //    Expenses.Add(Expense);

        //    return await Task.FromResult(true);
        //}


        //-----------Delete Functions-------------
        public async Task<bool> DeleteIncomeAsync(string id)
        {
            var oldExpense = IncomeSources.Where((Expense arg) => arg.Id == id).FirstOrDefault();
            IncomeSources.Remove(oldExpense);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteSavingsAsync(string id)
        {
            var oldExpense = Savings.Where((Expense arg) => arg.Id == id).FirstOrDefault();
            Savings.Remove(oldExpense);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMonthlyExpenseAsync(string id)
        {
            var oldExpense = MonthlyExpenses.Where((Expense arg) => arg.Id == id).FirstOrDefault();
            MonthlyExpenses.Remove(oldExpense);
            return await Task.FromResult(true);
        }


        //-----------Get Functions-------------
        public async Task<Expense> GetIncomeAsync(string id)
        {
            return await Task.FromResult(IncomeSources.FirstOrDefault(s => s.Id == id));
        }

        public async Task<Expense> GetSavingAsync(string id)
        {
            return await Task.FromResult(Savings.FirstOrDefault(s => s.Id == id));
        }

        public async Task<Expense> GetMonthlyExpenseAsync(string id)
        {
            return await Task.FromResult(MonthlyExpenses.FirstOrDefault(s => s.Id == id));
        }


        //-----------Get (multi) Functions-------------
        public async Task<ObservableCollection<Expense>> GetIncomeSoursesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(IncomeSources);
        }

        public async Task<ObservableCollection<Expense>> GetSavingsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Savings);
        }

        public async Task<ObservableCollection<Expense>> GetMonthlyExpensesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(MonthlyExpenses);
        }

    }
}