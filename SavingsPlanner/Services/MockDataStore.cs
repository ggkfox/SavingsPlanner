using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingsPlanner.Models;

namespace SavingsPlanner.Services
{
    public class MockDataStore : IDataStore<Expense>
    {
        List<Expense> Expenses;

        public MockDataStore()
        {
            Expenses = new List<Expense>();
            var mockExpenses = new List<Expense>();
            //{
            //                new Expense { Id = Guid.NewGuid().ToString(), Text = "First Expense", Description="This is an Expense description." },
            //                new Expense { Id = Guid.NewGuid().ToString(), Text = "Second Expense", Description="This is an Expense description." },
            //                new Expense { Id = Guid.NewGuid().ToString(), Text = "Third Expense", Description="This is an Expense description." },
            //                new Expense { Id = Guid.NewGuid().ToString(), Text = "Fourth Expense", Description="This is an Expense description." },
            //                new Expense { Id = Guid.NewGuid().ToString(), Text = "Fifth Expense", Description="This is an Expense description." },
            //                new Expense { Id = Guid.NewGuid().ToString(), Text = "Sixth Expense", Description="This is an Expense description." }
            //};

            foreach (var Expense in mockExpenses)
            {
                Expenses.Add(Expense);
            }
        }

        public async Task<bool> AddExpenseAsync(Expense Expense)
        {
            Expenses.Add(Expense);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateExpenseAsync(Expense Expense)
        {
            var oldExpense = Expenses.Where((Expense arg) => arg.Id == Expense.Id).FirstOrDefault();
            Expenses.Remove(oldExpense);
            Expenses.Add(Expense);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteExpenseAsync(string id)
        {
            var oldExpense = Expenses.Where((Expense arg) => arg.Id == id).FirstOrDefault();
            Expenses.Remove(oldExpense);

            return await Task.FromResult(true);
        }

        public async Task<Expense> GetExpenseAsync(string id)
        {
            return await Task.FromResult(Expenses.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Expense>> GetExpensesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Expenses);
        }

        //public Task<Expense> GetItemAsync(string id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}