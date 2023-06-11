using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts.OrdersDetails.Queries;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.OrdersDetails;

public class GetOrdersDetailsByOrderIdHandler : HandlerBase, IRequestHandler<GetOrdersDetailsByOrderId, GetOrdersDetailsByOrderIdResponse>
{
    public GetOrdersDetailsByOrderIdHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<GetOrdersDetailsByOrderIdResponse> Handle(GetOrdersDetailsByOrderId query, CancellationToken cancellationToken)
    {
        var result = await restaurantSystemContext.OrdersDetails.Where(x => x.IsActive && x.OrderID == query.OrderId).ToListAsync();

        return new GetOrdersDetailsByOrderIdResponse()
        {
            OrderDetails = OrdersDetailsMapper.MapToContract(result)
        };
    }
}
