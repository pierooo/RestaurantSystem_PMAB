using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts;
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
        try
        {
            var result = await RestaurantSystemContext.Reservations.SingleAsync(x => x.IsActive && x.ID == request.Id);

            return new GetReservationByIdResponse()
            {
                Data = ReservationsMapper.MapToContract(result)
            };
        }
        catch (Exception ex)
        {
            return new GetReservationByIdResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ": " + ex.Message)
            };
        }
    }
}