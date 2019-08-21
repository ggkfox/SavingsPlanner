using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using SavingsPlanner.Models;
using SavingsPlanner.Views;
using System.Collections.Generic;

namespace SavingsPlanner.ViewModels
{
    public class SavingsDetailViewModel : BaseViewModel
    {
        public ObservableCollection<Expense> Expenses { get; set; }
        public Command LoadExpensesCommand { get; set; }

        public SavingsDetailViewModel()
        {
            Expenses = new ObservableCollection<Expense>();
            LoadExpensesCommand = new Command(async () => await ExecuteLoadExpensesCommand());
        }

        public Command<Expense> RemoveExpense
        {
            get
            {
                return new Command<Expense>((expense) =>
                {
                    Expenses.Remove(expense);
                });
            }
        }

        public Command<Expense> addSavings
        {
            get
            {
                return new Command<Expense>((expense) =>
                {
                    Expenses.Add(expense);
                });
            }
        }

        public async Task SaveChanges()
        {
            await DraftBudget.AssignSavingsAsync(Expenses);
        }

        async Task ExecuteLoadExpensesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Expenses.Clear();
                var items = await DraftBudget.GetSavingsAsync(true);
                foreach (var item in items)
                {
                    Expenses.Add(item);
                }
                if (Expenses.Count == 0)
                {
                    Expenses.Add(new Expense { Id = Guid.NewGuid().ToString(), Title = "", Amount = 0 });
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

    }
}
