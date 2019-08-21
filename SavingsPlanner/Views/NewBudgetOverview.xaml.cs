using System;
using System.Collections.Generic;
using SavingsPlanner.Models;
using SavingsPlanner.ViewModels;
using Xamarin.Forms;

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

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    viewModel.LoadDraftData.Execute(null);
        //}
    }
}
