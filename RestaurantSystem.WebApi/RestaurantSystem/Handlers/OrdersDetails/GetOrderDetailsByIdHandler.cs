using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.OrdersDetails.Queries;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.OrdersDetails;

public class GetOrderDetailsByIdHandler : HandlerBase, IRequestHandler<GetOrderDetailsById, GetOrderDetailsByIdResponse>
{
    public GetOrderDetailsByIdHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<GetOrderDetailsByIdResponse> Handle(GetOrderDetailsById query, CancellationToken cancellationToken)
    {
        try
        {
            var result = await RestaurantSystemContext.OrdersDetails.SingleAsync(x => x.IsActive && x.ID == query.Id);

            return new GetOrderDetailsByIdResponse()
            {
                Data = OrdersDetailsMapper.MapToContract(result)
            };
        }
        catch (Exception ex)
        {
            return new GetOrderDetailsByIdResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ": " + ex.Message)
            };
        }
    }
}
