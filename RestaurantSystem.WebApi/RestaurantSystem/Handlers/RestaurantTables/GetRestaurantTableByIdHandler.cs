using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts;
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
        try
        {
            var result = await RestaurantSystemContext.RestaurantTables.SingleAsync(x => x.IsActive && x.ID == request.Id);

            return new GetRestaurantTableByIdResponse()
            {
                Data = RestaurantTablesMapper.MapToContract(result)
            };
        }
        catch (Exception ex)
        {
            return new GetRestaurantTableByIdResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ": " + ex.Message)
            };
        }
    }
}