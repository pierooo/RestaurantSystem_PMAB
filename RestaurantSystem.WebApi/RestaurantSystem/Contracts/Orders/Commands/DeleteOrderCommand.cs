using MediatR;

namespace RestaurantSystem.Contracts.Orders.Commands;

public class DeleteOrderCommand : IRequest<DeleteOrderResponse>
{
    public int Id { get; set; }
}
