using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Orders;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditOrderPage : ContentPage
    {
        public Order Order { get; set; }

        public EditOrderPage(Order order)
        {
            Order = order;
            InitializeComponent();
            BindingContext = new EditOrderViewModel(order);
        }
    }
}