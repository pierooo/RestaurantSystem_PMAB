using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts.Orders.Queries;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Orders;

public class GetOrdersHandler : HandlerBase, IRequestHandler<GetOrders, GetOrdersResponse>
{
    public GetOrdersHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<GetOrdersResponse> Handle(GetOrders request, CancellationToken cancellationToken)
    {
        var result = await restaurantSystemContext.Orders.Where(x => x.IsActive).ToListAsync();

        return new GetOrdersResponse()
        {
            Orders = OrdersMapper.MapToContract(result)
        };
    }
}
