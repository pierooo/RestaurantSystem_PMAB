using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Orders.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.Orders;

public class DeleteOrderCommandHandler : HandlerBase, IRequestHandler<DeleteOrderCommand, CommandResponse>
{
    public DeleteOrderCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        var item = await restaurantSystemContext.Orders.FindAsync(command.Id, cancellationToken);

        if (item == null)
        {
            throw new Exception("Entity not found: " + nameof(Orders));
        }

        item.IsActive = false;

        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}

