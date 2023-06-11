using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.OrdersDetails.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.OrdersDetails;

public class DeleteOrderDetailsCommandHandler : HandlerBase, IRequestHandler<DeleteOrderDetailsCommand, CommandResponse>
{
    public DeleteOrderDetailsCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(DeleteOrderDetailsCommand command, CancellationToken cancellationToken)
    {
        var item = await restaurantSystemContext.OrdersDetails.FindAsync(command.Id);

        if (item == null)
        {
            throw new Exception("Entity not found: " + nameof(OrdersDetails));
        }

        item.IsActive = false;

        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}
