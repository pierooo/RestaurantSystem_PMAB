using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Categories.Commands;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Categories;

public class AddCategoryCommandHandler : HandlerBase, IRequestHandler<AddCategoryCommand, AddCategoryResponse>
{
    public AddCategoryCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<AddCategoryResponse> Handle(AddCategoryCommand command, CancellationToken cancellationToken)
    {
        try
        {
            RestaurantSystemContext.Categories.Add(CategoriesMapper.MapToDbModel(command));
            await RestaurantSystemContext.SaveChangesAsync();
            return new AddCategoryResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new AddCategoryResponse()
            {
                Error = new ErrorModel(ex.Message)
            };
        }
    }
}
