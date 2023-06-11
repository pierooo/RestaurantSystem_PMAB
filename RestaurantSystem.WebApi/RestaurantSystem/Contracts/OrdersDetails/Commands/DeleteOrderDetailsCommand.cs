using MediatR;

namespace RestaurantSystem.Contracts.OrdersDetails.Commands;

public class DeleteOrderDetailsCommand : IRequest<CommandResponse>
{
    public int Id { get; set; }
}
