using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.RestaurantTables.Commands;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.RestaurantTables;

public class AddRestaurantTableCommandHandler : HandlerBase, IRequestHandler<AddRestaurantTableCommand, AddRestaurantTableResponse>
{
    public AddRestaurantTableCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<AddRestaurantTableResponse> Handle(AddRestaurantTableCommand command, CancellationToken cancellationToken)
    {
        try
        {
            RestaurantSystemContext.RestaurantTables.Add(RestaurantTablesMapper.MapToDbModel(command));
            await RestaurantSystemContext.SaveChangesAsync();
            return new AddRestaurantTableResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new AddRestaurantTableResponse()
            {
                Error = new ErrorModel(ex.Message)
            };
        }
    }
}

