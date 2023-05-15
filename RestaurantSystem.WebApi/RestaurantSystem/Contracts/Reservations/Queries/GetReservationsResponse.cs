using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.Reservations.Queries;

public class GetReservationsResponse : ResponseBase<IReadOnlyCollection<Reservation>>
{
}
