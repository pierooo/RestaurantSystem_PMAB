using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts;
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
        try
        {
            var result = await RestaurantSystemContext.RestaurantTables.Where(x => x.IsActive).ToListAsync();

            return new GetRestaurantTablesResponse()
            {
                Data = RestaurantTablesMapper.MapToContract(result)
            };
        }
        catch (Exception ex)
        {
            return new GetRestaurantTablesResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ": " + ex.Message)
            };
        }
    }
}