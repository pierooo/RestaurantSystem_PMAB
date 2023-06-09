using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts.Orders.Queries;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Orders;

public class GetOrderByIdHandler : HandlerBase, IRequestHandler<GetOrderById, GetOrderByIdResponse>
{
    public GetOrderByIdHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<GetOrderByIdResponse> Handle(GetOrderById query, CancellationToken cancellationToken)
    {
        var result = await restaurantSystemContext.Orders.SingleAsync(x => x.IsActive && x.ID == query.Id);

        return new GetOrderByIdResponse()
        {
            Order = OrdersMapper.MapToContract(result)
        };
    }
}