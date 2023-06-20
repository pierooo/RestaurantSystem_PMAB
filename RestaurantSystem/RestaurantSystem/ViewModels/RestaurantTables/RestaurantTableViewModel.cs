using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Abstract;
using RestaurantSystem.Views;
using Xamarin.Forms;

namespace RestaurantSystem.ViewModels.RestaurantTables
{
    public class RestaurantTableViewModel : AListViewModel<RestaurantTable>
    {
        public RestaurantTableViewModel()
            : base("Stoliki!")
        {
        }

        public override Page EditPage(RestaurantTable item)
        {
            return new EditRestaurantTablePage(item);
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(AddRestaurantTablePage));
        }
    }
}
