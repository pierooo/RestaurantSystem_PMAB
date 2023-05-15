using MediatR;

namespace RestaurantSystem.Contracts.Reservations.Queries;

public class GetReservationById : IRequest<GetReservationByIdResponse>
{
    public int Id { get; set; }
}
