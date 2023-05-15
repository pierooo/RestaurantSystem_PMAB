using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Reservations.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.Reservations;

public class DeleteReservationCommandHandler : HandlerBase, IRequestHandler<DeleteReservationCommand, DeleteReservationResponse>
{
    public DeleteReservationCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<DeleteReservationResponse> Handle(DeleteReservationCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var item = await RestaurantSystemContext.Reservations.FindAsync(command.Id);

            if (item == null)
            {
                return new DeleteReservationResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            item.IsActive = false;

            await RestaurantSystemContext.SaveChangesAsync();

            return new DeleteReservationResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new DeleteReservationResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
    }
}

