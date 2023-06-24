using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantSystem.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
			ProductsButton.Clicked += ProductsButton_Clicked;

		}
		private void ProductsButton_Clicked(object sender, EventArgs e)
		{
			// Navigate to the ProductsPage.xaml
			Navigation.PushAsync(new ProductsPage());
		}
	}
}