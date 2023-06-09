﻿using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Categories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCategoryPage : ContentPage
    {
        public Category Item { get; set; }

        public AddCategoryPage()
        {
            InitializeComponent();
            BindingContext = new AddCategoryViewModel();
        }
    }
}