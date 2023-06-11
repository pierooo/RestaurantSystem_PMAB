using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts.Reservations.Queries;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Reservations;

public class GetReservationsHandler : HandlerBase, IRequestHandler<GetReservations, GetReservationsResponse>
{
    public GetReservationsHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<GetReservationsResponse> Handle(GetReservations request, CancellationToken cancellationToken)
    {
        var result = await restaurantSystemContext.Reservations.Where(x => x.IsActive).ToListAsync();

        return new GetReservationsResponse()
        {
            Reservations = ReservationsMapper.MapToContract(result)
        };
    }
}

