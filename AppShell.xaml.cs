using System;
using System.Collections.Generic;
using IncomeAndExpenses.ViewModels;
using IncomeAndExpenses.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace IncomeAndExpenses
{
    

    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CategoriesListPage), typeof(CategoriesListPage));
            Routing.RegisterRoute(nameof(NewCategoryPage), typeof(NewCategoryPage));
            Routing.RegisterRoute(nameof(UpdateCategoryPage), typeof(UpdateCategoryPage));


            Routing.RegisterRoute(nameof(RecordListPage), typeof(RecordListPage));
            Routing.RegisterRoute(nameof(NewRecordPage), typeof(NewRecordPage));
            Routing.RegisterRoute(nameof(UpdateRecordPage), typeof(UpdateRecordPage));

            Routing.RegisterRoute(nameof(CalculatePage), typeof(CalculatePage));

        }
    }
}
