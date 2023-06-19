using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Abstract;

namespace RestaurantSystem.ViewModels.Orders
{
    public class EditOrderViewModel : AEditViewModel<Order>
    {
        private readonly int id;
        private int restaurantTableId;
        private string description;

        public int RestaurantTableId
        {
            get => restaurantTableId;
            set => SetProperty(ref restaurantTableId, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public EditOrderViewModel(Order order)
            : base()
        {
            this.id = order.Id;
            this.description = order.Description;
            this.RestaurantTableId = order.RestaurantTableID;
        }

        public override Order SetItem()
        {
            return new Order
            {
                Id = this.id,
                RestaurantTableID = this.RestaurantTableId,
                Description = this.description,
            };
        }

        public override bool ValidateSave()
        {
            return true;
        }
    }
}
