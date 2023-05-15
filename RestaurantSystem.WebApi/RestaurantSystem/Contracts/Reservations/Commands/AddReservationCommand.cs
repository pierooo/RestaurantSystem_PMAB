using MediatR;

namespace RestaurantSystem.Contracts.Reservations.Commands;

public class AddReservationCommand : IRequest<AddReservationResponse>
{
    public int RestaurantTableId { get; set; }

    public DateTime ReservationDate { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }
}
