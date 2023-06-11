using MediatR;

namespace RestaurantSystem.Contracts.Orders.Commands;

public class DeleteOrderCommand : IRequest<CommandResponse>
{
    public int Id { get; set; }
}
