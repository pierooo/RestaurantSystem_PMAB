using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Abstract;
using RestaurantSystem.Views;
using Xamarin.Forms;

namespace RestaurantSystem.ViewModels.Orders
{
    public class OrdersViewModel : AListViewModel<Order>
    {
        public OrdersViewModel()
            : base("Zamówienia!")
        {
        }

        public override Page EditPage(Order item)
        {
            return new EditOrderPage(item);
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(AddOrderPage));
        }
    }
}
