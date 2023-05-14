using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Categories.Queries;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Categories;

public class GetCategoryByIdHandler : HandlerBase, IRequestHandler<GetCategoryById, GetCategoryByIdResponse>
{
    public GetCategoryByIdHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<GetCategoryByIdResponse> Handle(GetCategoryById request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await RestaurantSystemContext.Categories.SingleAsync(x => x.IsActive && x.ID == request.Id);
            return new GetCategoryByIdResponse()
            {
                Data = CategoriesMapper.MapToContract(result)
            };
        }
        catch (Exception ex)
        {
            return new GetCategoryByIdResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ex.Message)
            };
        }
    }
}
