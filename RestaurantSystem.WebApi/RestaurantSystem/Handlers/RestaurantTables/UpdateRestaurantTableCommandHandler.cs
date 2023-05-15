using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.RestaurantTables.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.RestaurantTables;

public class UpdateRestaurantTableCommandHandler : HandlerBase, IRequestHandler<UpdateRestaurantTableCommand, UpdateRestaurantTableResponse>
{
    public UpdateRestaurantTableCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<UpdateRestaurantTableResponse> Handle(UpdateRestaurantTableCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var item = await RestaurantSystemContext.RestaurantTables.FindAsync(command.Id);

            if (item == null)
            {
                return new UpdateRestaurantTableResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            item.Name = command.Name;
            item.Description = command.Description;
            item.MaxCapacity = command.MaxCapacity;
            item.PhotoUrl = command.PhotoUrl;
            item.UpdatedAt = DateTime.UtcNow;

            await RestaurantSystemContext.SaveChangesAsync();

            return new UpdateRestaurantTableResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new UpdateRestaurantTableResponse()
            {
                Error = new ErrorModel(ex.Message)
            };
        }
    }
}
