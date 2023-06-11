using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts.RestaurantTables.Queries;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.RestaurantTables;

public class GetRestaurantTablesHandler : HandlerBase, IRequestHandler<GetRestaurantTables, GetRestaurantTablesResponse>
{
    public GetRestaurantTablesHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<GetRestaurantTablesResponse> Handle(GetRestaurantTables request, CancellationToken cancellationToken)
    {
        var result = await restaurantSystemContext.RestaurantTables.Where(x => x.IsActive).ToListAsync();

        return new GetRestaurantTablesResponse()
        {
            RestaurantTables = RestaurantTablesMapper.MapToContract(result)
        };
    }
}