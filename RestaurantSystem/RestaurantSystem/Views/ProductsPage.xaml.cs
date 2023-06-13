using RestaurantSystem.ViewModels.Products;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        private ProductsViewModel _viewModel;

        public ProductsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ProductsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}