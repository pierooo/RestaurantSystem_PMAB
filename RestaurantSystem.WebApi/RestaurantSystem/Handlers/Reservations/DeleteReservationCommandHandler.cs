using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Reservations.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.Reservations;

public class DeleteReservationCommandHandler : HandlerBase, IRequestHandler<DeleteReservationCommand, CommandResponse>
{
    public DeleteReservationCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(DeleteReservationCommand command, CancellationToken cancellationToken)
    {
        var item = await restaurantSystemContext.Reservations.FindAsync(command.Id);

        if (item == null)
        {
            throw new Exception("Entity not found: " + nameof(Reservations));
        }

        item.IsActive = false;

        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}

