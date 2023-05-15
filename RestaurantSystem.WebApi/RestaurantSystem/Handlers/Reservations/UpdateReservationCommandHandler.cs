using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Reservations.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.Reservations;

public class UpdateReservationCommandHandler : HandlerBase, IRequestHandler<UpdateReservationCommand, UpdateReservationResponse>
{
    public UpdateReservationCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<UpdateReservationResponse> Handle(UpdateReservationCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var item = await RestaurantSystemContext.Reservations.FindAsync(command.Id);

            if (item == null)
            {
                return new UpdateReservationResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            item.RestaurantTableId = command.RestaurantTableId;
            item.Description = command.Description;
            item.ReservationDate = command.ReservationDate;
            item.Status = command.Status;
            item.UpdatedAt = DateTime.UtcNow;

            await RestaurantSystemContext.SaveChangesAsync();

            return new UpdateReservationResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new UpdateReservationResponse()
            {
                Error = new ErrorModel(ex.Message)
            };
        }
    }
}

