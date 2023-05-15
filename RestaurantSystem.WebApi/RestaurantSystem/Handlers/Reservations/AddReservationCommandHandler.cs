using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Entities;
using RestaurantSystem.Contracts.Reservations.Commands;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Reservations;

public class AddReservationCommandHandler : HandlerBase, IRequestHandler<AddReservationCommand, AddReservationResponse>
{
    public AddReservationCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<AddReservationResponse> Handle(AddReservationCommand command, CancellationToken cancellationToken)
    {
        try
        {
            RestaurantSystemContext.Reservations.Add(ReservationsMapper.MapToDbModel(command));
            await RestaurantSystemContext.SaveChangesAsync();
            return new AddReservationResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new AddReservationResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ": " + nameof(RestaurantTable))
            };
        }
    }
}

