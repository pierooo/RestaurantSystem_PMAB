using RestaurantSystem.Models;
using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Abstract;
using RestaurantSystem.Views;
using Xamarin.Forms;

namespace RestaurantSystem.ViewModels.OrdersDetails
{
    public class AddOrderDetailsViewModel : ANewViewModel<OrderDetails>
    {
        private int quantity;
        private int productID;
        private Order order;

        public int Quantity
        {
            get => quantity;
            set => SetProperty(ref quantity, value);
        }

        public int ProductID
        {
            get => productID;
            set => SetProperty(ref productID, value);
        }

        public AddOrderDetailsViewModel(Order order)
            : base()
        {
            this.order = order;
        }

        public override OrderDetails SetItem()
        {
            return new OrderDetails
            {
                OrderID = this.order.Id,
                ProductID = this.productID,
                Quantity = this.quantity,
            };
        }

        public override bool ValidateSave()
        {
            return true;
        }

        public override async void BackToMainPageWithEntities()
        {
            var detailsPage = new OrderDetailsPage(order);
            await Shell.Current.Navigation.PushAsync(detailsPage);
        }
    }
}
