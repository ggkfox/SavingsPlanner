using System;
using System.Collections.ObjectModel;

namespace SavingsPlanner.Models
{
    public class Budget
    {
        public ObservableCollection<Expense> IncomeSources { get; set; }
        public ObservableCollection<Expense> Savings { get; set; }
        public ObservableCollection<Expense> MonthlyExpenses { get; set; }
        public int TakeHome { get; set; }
    }
}