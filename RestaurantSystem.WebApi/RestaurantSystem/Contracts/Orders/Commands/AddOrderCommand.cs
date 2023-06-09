using MediatR;

namespace RestaurantSystem.Contracts.Orders.Commands;

public class AddOrderCommand : IRequest<CommandResponse>
{
    public int RestaurantTableID { get; set; }

    public string? Description { get; set; }
}
