using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.OrdersDetails.Queries;

public class GetOrdersDetailsByOrderIdResponse : ResponseBase<IReadOnlyCollection<OrderDetails>>
{
}
