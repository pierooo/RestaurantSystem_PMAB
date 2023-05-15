using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Entities;
using RestaurantSystem.Contracts.Orders.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.Orders;

public class UpdateOrderCommandHandler : HandlerBase, IRequestHandler<UpdateOrderCommand, UpdateOrderResponse>
{
    public UpdateOrderCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<UpdateOrderResponse> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var item = await RestaurantSystemContext.Orders.FindAsync(command.Id);

            if (item == null)
            {
                return new UpdateOrderResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            item.RestaurantTableID = command.RestaurantTableID;
            item.Description = command.Description;
            item.Status = command.Status;
            item.UpdatedAt = DateTime.UtcNow;

            await RestaurantSystemContext.SaveChangesAsync();

            return new UpdateOrderResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new UpdateOrderResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ": " + nameof(RestaurantTable))
            };
        }
    }
}
