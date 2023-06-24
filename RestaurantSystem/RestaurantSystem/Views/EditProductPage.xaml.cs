using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Products;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProductPage : ContentPage
    {
        public Product Product { get; set; }

        public EditProductPage(Product category)
        {
            Product = category;
            InitializeComponent();
            BindingContext = new EditProductViewModel(category);
        }
    }
}