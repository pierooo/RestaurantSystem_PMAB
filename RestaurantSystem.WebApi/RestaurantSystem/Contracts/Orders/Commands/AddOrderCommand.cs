using MediatR;

namespace RestaurantSystem.Contracts.Orders.Commands;

public class AddOrderCommand : IRequest<AddOrderResponse>
{
    public int RestaurantTableID { get; set; }

    public string? Description { get; set; }
}
