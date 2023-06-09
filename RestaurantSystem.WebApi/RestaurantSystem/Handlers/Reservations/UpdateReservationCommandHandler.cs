using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Reservations.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.Reservations;

public class UpdateReservationCommandHandler : HandlerBase, IRequestHandler<UpdateReservationCommand, CommandResponse>
{
    public UpdateReservationCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(UpdateReservationCommand command, CancellationToken cancellationToken)
    {
        var item = await restaurantSystemContext.Reservations.FindAsync(command.Id);

        if (item == null)
        {
            throw new Exception("Entity not found: " + nameof(Reservations));

        }

        item.RestaurantTableId = command.RestaurantTableId;
        item.Description = command.Description;
        item.ReservationDate = command.ReservationDate;
        item.Status = command.Status;
        item.UpdatedAt = DateTime.UtcNow;

        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}

