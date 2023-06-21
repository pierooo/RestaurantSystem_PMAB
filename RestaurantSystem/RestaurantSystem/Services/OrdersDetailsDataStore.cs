using System.Linq;
using System.Threading.Tasks;
using RestaurantSystem.Service.Reference;
using RestaurantSystem.Services.Abstract;

namespace RestaurantSystem.Services
{
    public class OrdersDetailsDataStore : AListDataStore<OrderDetails>
    {
        public int OrderId { get; set; }

        public OrdersDetailsDataStore()
            : base()
        {
        }

        public override async Task AddItemToService(OrderDetails item)
        {
            await _service.OrdersDetails3Async(new AddOrderDetailsCommand
            {
                OrderID = item.OrderID,
                ProductID = item.ProductID,
                Quantity = item.Quantity,
            });
        }

        public override async Task DeleteItemFromService(OrderDetails item)
        {
            await _service.OrdersDetails2Async(item.Id);
        }

        public override async Task<OrderDetails> Find(OrderDetails item)
        {
            var tmp = await _service.OrdersDetailsAsync(item.Id);
            return new OrderDetails
            {
                Id = item.Id,
                OrderID = tmp.OrderDetails.Id,
                ProductID = tmp.OrderDetails.ProductID,
                Quantity = tmp.OrderDetails.Quantity,
                Vat = tmp.OrderDetails.Vat,
                UnitPriceGross = tmp.OrderDetails.UnitPriceGross
            };
        }

        public override async Task<OrderDetails> Find(int id)
        {
            var tmp = await _service.OrdersDetailsAsync(id);
            return new OrderDetails
            {
                Id = tmp.OrderDetails.Id,
                OrderID = tmp.OrderDetails.Id,
                ProductID = tmp.OrderDetails.ProductID,
                Quantity = tmp.OrderDetails.Quantity,
                Vat = tmp.OrderDetails.Vat,
                UnitPriceGross = tmp.OrderDetails.UnitPriceGross
            };
        }

        public override async Task RefreshListFromService(int? originatorId)
        {
            var tmp = await _service.OrderAsync(orderId: originatorId.Value);
            items = tmp.OrderDetails.Select(item => new OrderDetails
            {
                Id = item.Id,
                OrderID = item.OrderID,
                ProductID = item.ProductID,
                Quantity = item.Quantity,
                Vat = item.Vat,
                UnitPriceGross = item.UnitPriceGross
            }).ToList();
        }

        public override async Task UpdateItemInService(OrderDetails item)
        {
            await _service.OrdersDetails4Async(new UpdateOrderDetailsCommand
            {
                Id = item.Id,
                ProductID = item.ProductID,
                Quantity = item.Quantity,
            });
        }
    }
}
