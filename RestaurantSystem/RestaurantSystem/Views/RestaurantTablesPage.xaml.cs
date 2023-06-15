using RestaurantSystem.ViewModels.RestaurantTables;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantTablesPage : ContentPage
    {
        private RestaurantTableViewModel _viewModel;
        public RestaurantTablesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RestaurantTableViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}