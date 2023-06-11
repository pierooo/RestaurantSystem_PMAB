using MediatR;

namespace RestaurantSystem.Contracts.Reservations.Commands;

public class UpdateReservationCommand : IRequest<CommandResponse>
{
    public int Id { get; set; }

    public int RestaurantTableId { get; set; }

    public DateTime ReservationDate { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }
}
