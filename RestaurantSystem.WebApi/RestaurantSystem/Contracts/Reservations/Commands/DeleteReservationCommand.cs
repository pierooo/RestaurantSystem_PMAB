using MediatR;

namespace RestaurantSystem.Contracts.Reservations.Commands;

public class DeleteReservationCommand : IRequest<CommandResponse>
{
    public int Id { get; set; }
}
