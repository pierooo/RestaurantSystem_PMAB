using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.Orders.Queries;

public class GetOrdersResponse : IResponseBase
{
    public IReadOnlyCollection<Order?>? Orders { get; set; }
}
