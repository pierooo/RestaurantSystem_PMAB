using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.OrdersDetails.Queries;

public class GetOrderDetailsByIdResponse : IResponseBase
{
    public OrderDetails? OrderDetails { get; set; }
}
