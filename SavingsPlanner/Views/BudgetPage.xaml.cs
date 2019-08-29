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
using SkiaSharp;

namespace SavingsPlanner.Views
{
    public partial class BudgetPage : ContentPage
    {
        BudgetViewModel viewModel;

        public BudgetPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new BudgetViewModel();

            //ButtonView.IsVisible = false;
        }

        protected override void OnAppearing()
        {
            viewModel.UpdatePieChart();
            base.OnAppearing();
        }

        public async void NewBudget_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new IncomeDetailPage()));
        }
    }
}
