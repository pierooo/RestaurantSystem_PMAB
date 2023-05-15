using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Categories.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.Categories;

public class UpdateCategoryCommandHandler : HandlerBase, IRequestHandler<UpdateCategoryCommand, UpdateCategoryResponse>
{
    public UpdateCategoryCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<UpdateCategoryResponse> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var item = await RestaurantSystemContext.Categories.FindAsync(command.Id);

            if (item == null)
            {
                return new UpdateCategoryResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            item.Name = command.Name;
            item.Description = command.Description;
            item.PhotoUrl = command.PhotoUrl;
            item.UpdatedAt = DateTime.UtcNow;

            await RestaurantSystemContext.SaveChangesAsync();

            return new UpdateCategoryResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new UpdateCategoryResponse()
            {
                Error = new ErrorModel(ex.Message)
            };
        }
    }
}
