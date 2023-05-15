using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.Orders.Queries;

public class GetOrdersResponse : ResponseBase<IReadOnlyCollection<Order>>
{
}
