using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Abstract;
using RestaurantSystem.Views;
using Xamarin.Forms;

namespace RestaurantSystem.ViewModels.Categories
{
    public class CategoriesViewModel : AListViewModel<Category>
    {
        public CategoriesViewModel()
            : base("Kategorie!")
        {
        }

        public override Page EditPage(Category item)
        {
            return new EditCategoryPage(item);
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(AddCategoryPage));
        }
    }
}
