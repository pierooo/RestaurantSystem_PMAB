using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.OrdersDetails.Queries;

public class GetOrdersDetailsByOrderIdResponse : IResponseBase
{
    public IReadOnlyCollection<OrderDetails>? OrderDetails { get; set; }
}
