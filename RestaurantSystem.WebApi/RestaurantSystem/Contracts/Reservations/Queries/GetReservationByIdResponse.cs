using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.Reservations.Queries;

public class GetReservationByIdResponse : IResponseBase
{
    public Reservation? Reservation { get; set; }
}
