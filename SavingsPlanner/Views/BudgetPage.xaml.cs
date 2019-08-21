using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SavingsPlanner.Views
{
    public partial class BudgetPage : ContentPage
    {
        public BudgetPage()
        {
            InitializeComponent();
        }

        public async void NewBudget_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new IncomeDetailPage()));
        }
    }
}
