using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.RestaurantTables.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.RestaurantTables;

public class DeleteRestaurantTableCommandHandler : HandlerBase, IRequestHandler<DeleteRestaurantTableCommand, CommandResponse>
{
    public DeleteRestaurantTableCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(DeleteRestaurantTableCommand command, CancellationToken cancellationToken)
    {
        var item = await restaurantSystemContext.RestaurantTables.FindAsync(command.Id);

        if (item == null)
        {
            throw new Exception("Entity not found: " + nameof(RestaurantTables));
        }

        item.IsActive = false;

        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}
