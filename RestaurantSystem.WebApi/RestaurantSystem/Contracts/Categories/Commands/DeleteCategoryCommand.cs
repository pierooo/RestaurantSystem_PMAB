using MediatR;

namespace RestaurantSystem.Contracts.Categories.Commands;

public class DeleteCategoryCommand : IRequest<DeleteCategoryResponse>
{
    public int Id { get; set; }
}
