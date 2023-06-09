using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Categories.Commands;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Categories;

public class AddCategoryCommandHandler : HandlerBase, IRequestHandler<AddCategoryCommand, CommandResponse>
{
    public AddCategoryCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(AddCategoryCommand command, CancellationToken cancellationToken)
    {
        restaurantSystemContext.Categories.Add(CategoriesMapper.MapToDbModel(command));
        await restaurantSystemContext.SaveChangesAsync();
        return new CommandResponse();
    }
}
