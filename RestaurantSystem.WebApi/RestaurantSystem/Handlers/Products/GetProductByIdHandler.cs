using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Products.Queries;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Products;

public class GetProductByIdHandler : HandlerBase, IRequestHandler<GetProductById, GetProductByIdResponse>
{
    public GetProductByIdHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<GetProductByIdResponse> Handle(GetProductById request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await RestaurantSystemContext.Products.SingleAsync(x => x.IsActive && x.ID == request.Id);

            return new GetProductByIdResponse()
            {
                Data = ProductsMapper.MapToContract(result)
            };
        }
        catch (Exception ex)
        {
            return new GetProductByIdResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ": " + ex.Message)
            };
        }
    }
}