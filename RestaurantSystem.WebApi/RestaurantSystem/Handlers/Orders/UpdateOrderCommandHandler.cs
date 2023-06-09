using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Orders.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.Orders;

public class UpdateOrderCommandHandler : HandlerBase, IRequestHandler<UpdateOrderCommand, CommandResponse>
{
    public UpdateOrderCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var item = await restaurantSystemContext.Orders.FindAsync(command.Id);

        if (item == null)
        {
            throw new Exception("Entity not found: " + nameof(Orders));
        }

        item.RestaurantTableID = command.RestaurantTableID;
        item.Description = command.Description;
        item.Status = command.Status;
        item.UpdatedAt = DateTime.UtcNow;

        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}
