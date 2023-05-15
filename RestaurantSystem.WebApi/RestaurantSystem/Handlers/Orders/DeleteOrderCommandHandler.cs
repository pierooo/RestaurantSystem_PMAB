using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Orders.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.Orders;

public class DeleteOrderCommandHandler : HandlerBase, IRequestHandler<DeleteOrderCommand, DeleteOrderResponse>
{
    public DeleteOrderCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<DeleteOrderResponse> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var item = await RestaurantSystemContext.Orders.FindAsync(command.Id);

            if (item == null)
            {
                return new DeleteOrderResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            item.IsActive = false;

            await RestaurantSystemContext.SaveChangesAsync();

            return new DeleteOrderResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new DeleteOrderResponse()
            {
                Error = new ErrorModel(ex.Message)
            };
        }
    }
}

