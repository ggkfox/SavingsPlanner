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
    public partial class IncomeDetailPage : ContentPage
    {
        IncomeDetailViewModel viewModel;

        public IncomeDetailPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new IncomeDetailViewModel();
        }

        public void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button?.BindingContext as Expense;
            viewModel.RemoveExpense.Execute(item);

        }

        public void AddExpense(object sender, EventArgs e)
        {
            viewModel.AddExpense.Execute(new Expense { Title = "", Amount = 0 });
        }

        public async void NextButton_Clicked(object sender, EventArgs e)
        {
            await viewModel.SaveChanges();
            await Navigation.PushAsync(new SavingsDetailPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Expenses.Count == 0)
            {
                viewModel.LoadExpensesCommand.Execute(null);
            }
            IsVisible = true;
        }
    }
}
