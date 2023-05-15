using MediatR;

namespace RestaurantSystem.Contracts.Orders.Queries;

public class GetOrderById : IRequest<GetOrderByIdResponse>
{
    public int Id { get; set; }
}
