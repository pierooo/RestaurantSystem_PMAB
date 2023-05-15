using MediatR;
using RestaurantSystem.Contracts.Categories.Queries;

namespace RestaurantSystem.Contracts.Reservations.Queries;

public class GetReservations : IRequest<GetReservationsResponse>
{
}
