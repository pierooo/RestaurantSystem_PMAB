using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts;
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
        try
        {
            var result = await RestaurantSystemContext.Orders.Where(x => x.IsActive).ToListAsync();

            return new GetOrdersResponse()
            {
                Data = OrdersMapper.MapToContract(result)
            };
        }
        catch (Exception ex)
        {
            return new GetOrdersResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ": " + ex.Message)
            };
        }
    }
}
