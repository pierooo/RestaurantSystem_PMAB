using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Abstract;
using RestaurantSystem.Views;
using Xamarin.Forms;

namespace RestaurantSystem.ViewModels.Orders
{
    public class OrdersViewModel : AListViewModel<Order>
    {
        public Command ViewDetailsCommand { get; }

        public OrdersViewModel()
            : base("Zamówienia!")
        {
            ViewDetailsCommand = new Command<int>(ExecuteGoToDetailsCommand);
        }

        public override Page EditPage(Order item)
        {
            return new EditOrderPage(item);
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(AddOrderPage));
        }

        private async void ExecuteGoToDetailsCommand(int id)
        {
            var item = await DataStore.GetItemAsync(id);
            var detailsPage = new OrderDetailsPage(item);
            await Shell.Current.Navigation.PushAsync(detailsPage);
        }
    }
}
