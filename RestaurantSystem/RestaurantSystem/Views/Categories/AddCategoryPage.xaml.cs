using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Categories;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantSystem.Views.Categories
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCategoryPage : ContentPage
    {
        public AddCategoryCommand Item { get; set; }

        public AddCategoryPage()
        {
            InitializeComponent();
            BindingContext = new AddCategoryViewModel();
        }
    }
}