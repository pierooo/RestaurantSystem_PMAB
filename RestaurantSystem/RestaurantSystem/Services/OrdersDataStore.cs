using RestaurantSystem.Service.Reference;
using RestaurantSystem.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantSystem.Services
{
    public class OrdersDataStore : AListDataStore<Order>
    {
        public OrdersDataStore()
            : base()
        {
        }

        public override async Task AddItemToService(Order item)
        {
            await _service.Orders2Async(new AddOrderCommand
            {
                RestaurantTableID = item.RestaurantTableID,
                Description = item.Description,
            });
        }

        public override async Task DeleteItemFromService(Order item)
        {
            await _service.Orders5Async(item.Id);
        }

        public override async Task<Order> Find(Order item)
        {
            var tmp = await _service.Orders4Async(item.Id);
            return new Order
            {
                Id = item.Id,
                RestaurantTableID = item.RestaurantTableID,
                Description = item.Description,
            };
        }

        public override async Task<Order> Find(int id)
        {
            var tmp = await _service.Orders4Async(id);
            return new Order
            {
                Id = tmp.Order.Id,
                RestaurantTableID = tmp.Order.RestaurantTableID,
                Description = tmp.Order.Description,
            };
        }

        public override async Task RefreshListFromService()
        {
            var tmp = _service.OrdersAsync(new GetOrders()).Result.Orders;
            items = tmp.Select(item => new Order
            {
                Id = item.Id,
                RestaurantTableID = item.RestaurantTableID,
                Description = item.Description,
            }).ToList();
        }

        public override async Task UpdateItemInService(Order item)
        {
            await _service.Orders3Async(new UpdateOrderCommand
            {
                Id = item.Id,
                RestaurantTableID = item.RestaurantTableID,
                Description = item.Description,
            });
        }
    }
}
