using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.Orders.Queries;

public class GetOrderByIdResponse : IResponseBase
{
    public Order? Order { get; set; }
}
