using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.OrdersDetails;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailsPage : ContentPage
    {
        private OrdersDetailsViewModel _viewModel;

        public OrderDetailsPage(Order order)
        {
            InitializeComponent();
            BindingContext = _viewModel = new OrdersDetailsViewModel(order);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}