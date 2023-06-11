using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts.RestaurantTables.Queries;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.RestaurantTables;

public class GetRestaurantTableByIdHandler : HandlerBase, IRequestHandler<GetRestaurantTableById, GetRestaurantTableByIdResponse>
{
    public GetRestaurantTableByIdHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<GetRestaurantTableByIdResponse> Handle(GetRestaurantTableById request, CancellationToken cancellationToken)
    {
        var result = await restaurantSystemContext.RestaurantTables.SingleAsync(x => x.IsActive && x.ID == request.Id);

        return new GetRestaurantTableByIdResponse()
        {
            RestaurantTable = RestaurantTablesMapper.MapToContract(result)
        };
    }
}