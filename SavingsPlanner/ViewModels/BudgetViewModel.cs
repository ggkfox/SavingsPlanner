using System;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Microcharts;

using Xamarin.Forms;

using SavingsPlanner.Models;
using SavingsPlanner.Views;
using System.Collections.Generic;

namespace SavingsPlanner.ViewModels
{
    public class BudgetViewModel : BaseViewModel
    {
        private ObservableCollection<Expense> _incomes = null;
        public ObservableCollection<Expense> Incomes
        {
            get
            {
                return _incomes;
            }
            set
            {
                _incomes = value;
                OnPropertyChanged("Incomes");
            }
        }
        private ObservableCollection<Expense> _savings = null;
        public ObservableCollection<Expense> Savings
        {
            get
            {
                return _savings;
            }
            set
            {
                _savings = value;
                OnPropertyChanged("Savings");
            }
        }
        private ObservableCollection<Expense> _expenses = null;
        public ObservableCollection<Expense> Expenses
        {
            get
            {
                return _expenses;
            }
            set
            {
                _expenses = value;
                OnPropertyChanged("Expenses");
            }
        }

        private ObservableCollection<Microcharts.Entry> entries { get; set; }
        private Chart _pieChart = null;
        public Chart PieChart
        {
            get
            {
                return _pieChart;
            }
            set
            {
                _pieChart = value;
                OnPropertyChanged("PieChart");
            }
        }


        public BudgetViewModel()
        {

            entries = new ObservableCollection<Microcharts.Entry>();

            PieChart = new Microcharts.DonutChart { Entries = entries };
        }

        public void UpdatePieChart()
        {
            entries.Clear();
            entries.Add(new Microcharts.Entry(Budget.GetSumOfAllSavings())
            {
                Color = SKColor.Parse("#FF1493"),
                Label = "Savings",
                ValueLabel = Budget.GetSumOfAllSavings().ToString()
            });
            entries.Add(new Microcharts.Entry(Budget.GetSumOfAllExpenses())
            {
                Color = SKColor.Parse("#00FF00"),
                Label = "Monthly expenses",
                ValueLabel = Budget.GetSumOfAllExpenses().ToString()
            });
            entries.Add(new Microcharts.Entry(Budget.GetRemainder())
            {
                Color = SKColor.Parse("#0000FF"),
                Label = "Budget to live",
                ValueLabel = Budget.GetRemainder().ToString()
            });

            PieChart = new Microcharts.DonutChart { Entries = entries };
        }


    }
}
