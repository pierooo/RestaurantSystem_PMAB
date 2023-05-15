using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.OrdersDetails.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.OrdersDetails;

public class DeleteOrderDetailsCommandHandler : HandlerBase, IRequestHandler<DeleteOrderDetailsCommand, DeleteOrderDetailsResponse>
{
    public DeleteOrderDetailsCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<DeleteOrderDetailsResponse> Handle(DeleteOrderDetailsCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var item = await RestaurantSystemContext.OrdersDetails.FindAsync(command.Id);

            if (item == null)
            {
                return new DeleteOrderDetailsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            item.IsActive = false;

            await RestaurantSystemContext.SaveChangesAsync();

            return new DeleteOrderDetailsResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new DeleteOrderDetailsResponse()
            {
                Error = new ErrorModel(ex.Message)
            };
        }
    }
}
