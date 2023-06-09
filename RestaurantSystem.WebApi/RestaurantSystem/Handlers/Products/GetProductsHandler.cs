using MediatR;
using Microsoft.EntityFrameworkCore;
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
        var result = await restaurantSystemContext.Products.Where(x => x.IsActive).ToListAsync();

        return new GetProductsResponse()
        {
            Products = ProductsMapper.MapToContract(result)
        };
    }
}


