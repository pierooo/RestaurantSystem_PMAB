using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.RestaurantTables.Commands;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.RestaurantTables;

public class AddRestaurantTableCommandHandler : HandlerBase, IRequestHandler<AddRestaurantTableCommand, CommandResponse>
{
    public AddRestaurantTableCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(AddRestaurantTableCommand command, CancellationToken cancellationToken)
    {
        restaurantSystemContext.RestaurantTables.Add(RestaurantTablesMapper.MapToDbModel(command));
        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}

