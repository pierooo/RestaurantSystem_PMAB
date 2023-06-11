using MediatR;
using Microsoft.EntityFrameworkCore;
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
        var result = await restaurantSystemContext.OrdersDetails.SingleAsync(x => x.IsActive && x.ID == query.Id);

        return new GetOrderDetailsByIdResponse()
        {
            OrderDetails = OrdersDetailsMapper.MapToContract(result)
        };
    }
}
