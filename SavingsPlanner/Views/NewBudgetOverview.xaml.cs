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
    public partial class NewBudgetOverview : ContentPage
    {
        NewBudgetOverviewViewModel viewModel;

        public NewBudgetOverview()
        {
            InitializeComponent();

            BindingContext = viewModel = new NewBudgetOverviewViewModel();
        }

        public async void SaveButton_Clicked(object sender, EventArgs e)
        {
            await viewModel.CommitChanges();
            await Navigation.PopModalAsync();
        }

        public async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadDraftData.Execute(null);
            IncomeLabel.Text = viewModel.IncomeSum;
            SavingsLabel.Text = viewModel.SavingsSum;
            ExpensesLabel.Text = viewModel.ExpensesSum;
            RemainderLabel.Text = viewModel.Remainder;

        }
    }
}
