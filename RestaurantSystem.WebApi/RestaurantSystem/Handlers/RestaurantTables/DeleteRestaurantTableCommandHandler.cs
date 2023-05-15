using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.RestaurantTables.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.RestaurantTables;

public class DeleteRestaurantTableCommandHandler : HandlerBase, IRequestHandler<DeleteRestaurantTableCommand, DeleteRestaurantTableResponse>
{
    public DeleteRestaurantTableCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<DeleteRestaurantTableResponse> Handle(DeleteRestaurantTableCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var item = await RestaurantSystemContext.RestaurantTables.FindAsync(command.Id);

            if (item == null)
            {
                return new DeleteRestaurantTableResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            item.IsActive = false;

            await RestaurantSystemContext.SaveChangesAsync();

            return new DeleteRestaurantTableResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new DeleteRestaurantTableResponse()
            {
                Error = new ErrorModel(ex.Message)
            };
        }
    }
}
