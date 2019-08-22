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

        public void SaveButton_Clicked()
        {

        }

        public void BackButton_Clicked()
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadDraftData.Execute(null);
        }
    }
}
