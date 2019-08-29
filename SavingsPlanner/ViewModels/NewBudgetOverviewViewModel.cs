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
    public class NewBudgetOverviewViewModel : BaseViewModel
    {
        public ObservableCollection<Expense> DraftIncome;
        public ObservableCollection<Expense> DraftSavings;
        public ObservableCollection<Expense> DraftExpenses;
        public string IncomeSum { get; set; }
        public string SavingsSum { get; set; }
        public string ExpensesSum { get; set; }
        public string Remainder { get; set; }

        public Command LoadDraftData { get; set; }

        public NewBudgetOverviewViewModel()
        {
            Title = "New Budget - Overview";

            DraftIncome = new ObservableCollection<Expense>();
            DraftSavings = new ObservableCollection<Expense>();
            DraftExpenses = new ObservableCollection<Expense>();

            LoadDraftData = new Command(async () => await ExecuteLoadDraftData());
        }

        public async Task CommitChanges()
        {
            await Budget.AssignAllIncomeAsync(DraftIncome);
            await Budget.AssignAllSavingsAsync(DraftSavings);
            await Budget.AssignAllExpensesAsync(DraftExpenses);
        }

        async Task ExecuteLoadDraftData()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                DraftIncome.Clear();
                DraftSavings.Clear();
                DraftExpenses.Clear();

                var items = await DraftBudget.GetIncomeSoursesAsync(true);
                foreach (var item in items)
                {
                    DraftIncome.Add(item);
                }

                items = await DraftBudget.GetSavingsAsync(true);
                foreach (var item in items)
                {
                    DraftSavings.Add(item);
                }

                items = await DraftBudget.GetMonthlyExpensesAsync(true);
                foreach (var item in items)
                {
                    DraftExpenses.Add(item);
                }

                int a = Budget.GetSumOfAllIncome();
                int b = Budget.GetSumOfAllSavings();
                int c = Budget.GetSumOfAllExpenses();
                IncomeSum = "Total Income: " + a.ToString();
                SavingsSum = "Total Savings: " + b.ToString();
                ExpensesSum = "All Monthly Expenses: " + c.ToString();
                Remainder = "Your remaining monthly budget: " + (a - b - c).ToString();

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
