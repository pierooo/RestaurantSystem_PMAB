using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Products.Queries;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Products;

public class GetProductsHandler : HandlerBase, IRequestHandler<GetProducts, GetProductsResponse>
{
    public GetProductsHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<GetProductsResponse> Handle(GetProducts request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await RestaurantSystemContext.Products.Where(x => x.IsActive).ToListAsync();

            return new GetProductsResponse()
            {
                Data = ProductsMapper.MapToContract(result)
            };
        }
        catch (Exception ex)
        {
            return new GetProductsResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ": " + ex.Message)
            };
        }
    }
}


