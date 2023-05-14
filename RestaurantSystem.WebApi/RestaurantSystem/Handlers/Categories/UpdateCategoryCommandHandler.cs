using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Categories.Commands;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

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
            var category = await RestaurantSystemContext.Categories.FindAsync(command.Id);

            if (category == null)
            {
                return new UpdateCategoryResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            category.Name = command.Name;
            category.Description = command.Description;
            category.PhotoUrl = command.PhotoUrl;
            category.UpdatedAt = DateTime.UtcNow;

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
