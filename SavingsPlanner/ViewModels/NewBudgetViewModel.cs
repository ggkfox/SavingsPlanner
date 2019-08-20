using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using SavingsPlanner.Models;
using SavingsPlanner.Views;

namespace SavingsPlanner.ViewModels
{
    public class NewBudgetViewModel : BaseViewModel
    {
        public ObservableCollection<Expense> Expenses { get; set; }
        public Command LoadExpensesCommand { get; set; }

        public NewBudgetViewModel()
        {
            Expenses = new ObservableCollection<Expense>();
            LoadExpensesCommand = new Command(async () => await ExecuteLoadExpensesCommand());

            Expenses.Add(new Expense
            {
                Title = "test",
                Amount = 34
            });
            Expenses.Add(new Expense
            {
                Title = "test1",
                Amount = 35
            });
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

        async Task ExecuteLoadExpensesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Expenses.Clear();
                var items = await DataStore.GetExpensesAsync(true);
                foreach (var item in items)
                {
                    Expenses.Add(item);
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
