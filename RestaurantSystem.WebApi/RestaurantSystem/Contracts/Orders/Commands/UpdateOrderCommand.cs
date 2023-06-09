using MediatR;

namespace RestaurantSystem.Contracts.Orders.Commands;

public class UpdateOrderCommand : IRequest<CommandResponse>
{
    public int Id { get; set; }

    public int RestaurantTableID { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }
}
