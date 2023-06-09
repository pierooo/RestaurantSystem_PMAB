using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Reservations.Commands;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Reservations;

public class AddReservationCommandHandler : HandlerBase, IRequestHandler<AddReservationCommand, CommandResponse>
{
    public AddReservationCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(AddReservationCommand command, CancellationToken cancellationToken)
    {
        restaurantSystemContext.Reservations.Add(ReservationsMapper.MapToDbModel(command));
        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}

