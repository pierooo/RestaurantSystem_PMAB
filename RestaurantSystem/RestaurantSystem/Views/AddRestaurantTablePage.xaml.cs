using RestaurantSystem.Service.Reference;

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