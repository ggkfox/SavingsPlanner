using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SavingsPlanner.Models;
using SavingsPlanner.Views;
using SavingsPlanner.ViewModels;

namespace SavingsPlanner.Views
{
    public partial class NewBudgetWizardPage : ContentPage
    {
        NewBudgetViewModel viewModel;
        public NewBudgetWizardPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new NewBudgetViewModel();
        }

        public void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button?.BindingContext as Expense;
            viewModel.RemoveExpense.Execute(item);

        }

        public void AddSavingsItem(object sender, EventArgs e)
        {
            viewModel.addSavings.Execute(new Expense { Title = "name", Amount = 0 });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Expenses.Count == 0)
            {
                viewModel.LoadExpensesCommand.Execute(null);
            }
        }
    }
}
