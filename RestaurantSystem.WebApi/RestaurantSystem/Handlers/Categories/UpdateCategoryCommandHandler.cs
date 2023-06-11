using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Categories.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.Categories;

public class UpdateCategoryCommandHandler : HandlerBase, IRequestHandler<UpdateCategoryCommand, CommandResponse>
{
    public UpdateCategoryCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var item = await restaurantSystemContext.Categories.FindAsync(command.Id);

        if (item == null)
        {
            throw new Exception("Entity not found: " + nameof(Categories));
        }

        item.Name = command.Name;
        item.Description = command.Description;
        item.PhotoUrl = command.PhotoUrl;
        item.UpdatedAt = DateTime.UtcNow;

        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}
