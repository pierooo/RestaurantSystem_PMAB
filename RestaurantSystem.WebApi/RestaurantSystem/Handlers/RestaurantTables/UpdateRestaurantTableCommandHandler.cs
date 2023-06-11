using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.RestaurantTables.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.RestaurantTables;

public class UpdateRestaurantTableCommandHandler : HandlerBase, IRequestHandler<UpdateRestaurantTableCommand, CommandResponse>
{
    public UpdateRestaurantTableCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(UpdateRestaurantTableCommand command, CancellationToken cancellationToken)
    {
        var item = await restaurantSystemContext.RestaurantTables.FindAsync(command.Id);

        if (item == null)
        {
            throw new Exception("Entity not found: " + nameof(RestaurantTables));
        }

        item.Name = command.Name;
        item.Description = command.Description;
        item.MaxCapacity = command.MaxCapacity;
        item.PhotoUrl = command.PhotoUrl;
        item.UpdatedAt = DateTime.UtcNow;

        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}
