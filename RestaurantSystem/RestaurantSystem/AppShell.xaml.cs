using RestaurantSystem.ViewModels;
using RestaurantSystem.Views;
using RestaurantSystem.Views.Categories;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RestaurantSystem
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute(nameof(CategoriesPage), typeof(CategoriesPage));
            Routing.RegisterRoute(nameof(AddCategoryPage), typeof(AddCategoryPage));
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
