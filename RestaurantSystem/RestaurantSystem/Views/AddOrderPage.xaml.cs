using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Orders;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrderPage : ContentPage
    {
        public Order Item { get; set; }

        public AddOrderPage()
        {
            InitializeComponent();
            BindingContext = new AddOrderViewModel();
        }
    }
}