using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Categories.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.Categories;

public class DeleteCategoryCommandHandler : HandlerBase, IRequestHandler<DeleteCategoryCommand, CommandResponse>
{
    public DeleteCategoryCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        var item = await restaurantSystemContext.Categories.FindAsync(command.Id, cancellationToken);

        if (item == null)
        {
            throw new Exception("Entity not found: " + nameof(Categories));
        }

        item.IsActive = false;

        await restaurantSystemContext.SaveChangesAsync();
        return new CommandResponse();
    }
}
