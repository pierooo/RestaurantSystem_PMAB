using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Abstract;
using RestaurantSystem.Views;
using Xamarin.Forms;

namespace RestaurantSystem.ViewModels.OrdersDetails
{
    public class OrdersDetailsViewModel : AListViewModel<OrderDetails>
    {
        private readonly Order order;

        public OrdersDetailsViewModel(Order order)
            : base($"Szczegóły zamówienia- {order.Description}")
        {
            base.OriginatorId = order.Id;
            this.order = order;
        }

        public override Page EditPage(OrderDetails item)
        {
            return new EditOrderDetailsPage();
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(AddOrderPage));
        }
    }
}
