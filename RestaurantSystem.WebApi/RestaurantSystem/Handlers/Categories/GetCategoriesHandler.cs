using MediatR;
using Microsoft.EntityFrameworkCore;
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
        var result = await restaurantSystemContext.Categories.Where(x => x.IsActive).ToListAsync();

        return new GetCategoriesResponse()
        {
            Categories = CategoriesMapper.MapToContract(result)
        };
    }
}
