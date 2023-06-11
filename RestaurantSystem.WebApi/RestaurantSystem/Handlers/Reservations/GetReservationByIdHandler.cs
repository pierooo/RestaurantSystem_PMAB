using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts.Reservations.Queries;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Reservations;

public class GetReservationByIdHandler : HandlerBase, IRequestHandler<GetReservationById, GetReservationByIdResponse>
{
    public GetReservationByIdHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<GetReservationByIdResponse> Handle(GetReservationById request, CancellationToken cancellationToken)
    {
        var result = await restaurantSystemContext.Reservations.SingleAsync(x => x.IsActive && x.ID == request.Id);

        return new GetReservationByIdResponse()
        {
            Reservation = ReservationsMapper.MapToContract(result)
        };
    }
}