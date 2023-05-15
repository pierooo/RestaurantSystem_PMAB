using MediatR;

namespace RestaurantSystem.Contracts.OrdersDetails.Commands;

public class DeleteOrderDetailsCommand : IRequest<DeleteOrderDetailsResponse>
{
    public int Id { get; set; }
}
