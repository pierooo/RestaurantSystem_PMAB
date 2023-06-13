using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Categories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCategoryPage : ContentPage
    {
        public Category Category { get; set; }

        public EditCategoryPage(Category category)
        {
            Category = category;
            InitializeComponent();
            BindingContext = new EditCategoryViewModel(category);
        }
    }
}