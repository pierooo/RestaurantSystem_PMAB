using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Products;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProductPage : ContentPage
    {
        public Product Item { get; set; }

        public AddProductPage()
        {
            InitializeComponent();
            BindingContext = new AddProductViewModel();
        }
    }
}