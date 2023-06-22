using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Abstract;
using Xamarin.Forms;

namespace RestaurantSystem.ViewModels.Orders
{
    public class AddOrderViewModel : ANewViewModel<Order>
    {
        private string description;
        private int restaurantTableId;

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public int RestaurantTableId
        {
            get => restaurantTableId;
            set => SetProperty(ref restaurantTableId, value);
        }

        public AddOrderViewModel()
            : base()
        {
        }

        public override Order SetItem()
        {
            return new Order
            {
                RestaurantTableID = this.restaurantTableId,
                Description = this.description
            };
        }

        public override bool ValidateSave()
        {
            return true;
        }

        public override async void BackToMainPageWithEntities()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
