using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Abstract;
using RestaurantSystem.Views.Categories;
using Xamarin.Forms;

namespace RestaurantSystem.ViewModels.Categories
{
    public class CategoriesViewModel : AListViewModel<Category>
    {
        public CategoriesViewModel()
            : base("Kategorie!")
        {
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(AddCategoryPage));
        }
    }
}
