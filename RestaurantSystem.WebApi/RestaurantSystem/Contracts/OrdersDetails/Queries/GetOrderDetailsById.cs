using MediatR;

namespace RestaurantSystem.Contracts.OrdersDetails.Queries;

public class GetOrderDetailsById : IRequest<GetOrderDetailsByIdResponse>
{
    public int Id { get; set; }
}