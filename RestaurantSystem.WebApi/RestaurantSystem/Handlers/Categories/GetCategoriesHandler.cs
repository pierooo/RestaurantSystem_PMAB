using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Categories.Queries;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Categories;

public class GetCategoriesHandler : HandlerBase, IRequestHandler<GetCategories, GetCategoriesResponse>
{
    public GetCategoriesHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<GetCategoriesResponse> Handle(GetCategories request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await RestaurantSystemContext.Categories.Where(x => x.IsActive).ToListAsync();

            return new GetCategoriesResponse()
            {
                Data = CategoriesMapper.MapToContract(result)
            };
        }
        catch (Exception ex)
        {
            return new GetCategoriesResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ex.Message)
            };
        }
    }
}
