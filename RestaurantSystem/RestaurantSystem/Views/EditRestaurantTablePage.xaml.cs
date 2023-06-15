using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.RestaurantTables;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditRestaurantTablePage : ContentPage
    {
        public RestaurantTable RestaurantTable { get; set; }

        public EditRestaurantTablePage(RestaurantTable restaurantTable)
        {
            RestaurantTable = restaurantTable;
            InitializeComponent();
            BindingContext = new EditRestaurantTableViewModel(restaurantTable);
        }
    }
}