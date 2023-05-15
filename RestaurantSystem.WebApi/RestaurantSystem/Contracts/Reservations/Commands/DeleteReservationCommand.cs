using MediatR;

namespace RestaurantSystem.Contracts.Reservations.Commands;

public class DeleteReservationCommand : IRequest<DeleteReservationResponse>
{
    public int Id { get; set; }
}
