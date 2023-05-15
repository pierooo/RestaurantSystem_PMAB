using MediatR;

namespace RestaurantSystem.Contracts.OrdersDetails.Queries;

public class GetOrdersDetailsByOrderId : IRequest<GetOrdersDetailsByOrderIdResponse>
{
    public int OrderId { get; set; }
}
