using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts;
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
        try
        {
            var result = await RestaurantSystemContext.Reservations.Where(x => x.IsActive).ToListAsync();

            return new GetReservationsResponse()
            {
                Data = ReservationsMapper.MapToContract(result)
            };
        }
        catch (Exception ex)
        {
            return new GetReservationsResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ": " + ex.Message)
            };
        }
    }
}

