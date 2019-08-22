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

            IncomeSum = "";
            SavingsSum = "";
            ExpensesSum = "";
            Remainder = "";

            LoadDraftData = new Command(async () => await ExecuteLoadDraftData());
        }

        public int Sum(ObservableCollection<Expense> items)
        {
            int sum = 0;
            foreach (var item in items)
            {
                sum += item.Amount;
            }
            return sum;
        }

        public void CommitChanges()
        {
            Budget.AssignIncomeAsync(DraftIncome);
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

                int a = Sum(DraftIncome);
                int b = Sum(DraftSavings);
                int c = Sum(DraftExpenses);
                int d = a - b - c;
                IncomeSum = a.ToString();
                SavingsSum = b.ToString();
                ExpensesSum = c.ToString();
                Remainder = d.ToString();

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
