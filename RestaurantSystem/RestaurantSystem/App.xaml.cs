using RestaurantSystem.Services;
using Xamarin.Forms;

namespace RestaurantSystem
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<CategoriesDataStore>();
            DependencyService.Register<ProductsDataStore>();
            DependencyService.Register<OrdersDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
