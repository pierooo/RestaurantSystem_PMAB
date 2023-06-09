using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.Reservations.Queries;

public class GetReservationsResponse : IResponseBase
{
    public IReadOnlyCollection<Reservation>? Reservations { get; set; }
}
