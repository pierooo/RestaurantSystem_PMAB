using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Abstract;
using RestaurantSystem.Views;
using Xamarin.Forms;

namespace RestaurantSystem.ViewModels.Products
{
    public class ProductsViewModel : AListViewModel<Product>
    {
        public ProductsViewModel()
            : base("Produkty!")
        {
        }

        public override Page EditPage(Product item)
        {
            return new EditProductPage(item);
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(AddProductPage));
        }
    }
}
