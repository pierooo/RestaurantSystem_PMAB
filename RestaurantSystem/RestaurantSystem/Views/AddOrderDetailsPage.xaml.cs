using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Orders;
using RestaurantSystem.ViewModels.OrdersDetails;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrderDetailsPage : ContentPage
    {
        public OrderDetails Item { get; set; }

        public AddOrderDetailsPage(Order order)
        {
            InitializeComponent();
            BindingContext = new AddOrderDetailsViewModel(order);
        }
    }
}