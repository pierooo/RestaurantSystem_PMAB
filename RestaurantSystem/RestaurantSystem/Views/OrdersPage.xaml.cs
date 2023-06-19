using RestaurantSystem.ViewModels.Orders;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage
    {
        private OrdersViewModel _viewModel;

        public OrdersPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new OrdersViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}