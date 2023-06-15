using RestaurantSystem.Service.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRestaurantTablePage : ContentPage
    {
        public RestaurantTable Item { get; set; }
        public AddRestaurantTablePage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.RestaurantTables.AddRestaurantTableViewModel();
        }
    }
}