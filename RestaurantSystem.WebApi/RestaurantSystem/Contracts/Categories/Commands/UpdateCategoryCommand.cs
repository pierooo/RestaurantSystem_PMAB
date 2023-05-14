using MediatR;

namespace RestaurantSystem.Contracts.Categories.Commands;

public class UpdateCategoryCommand : IRequest<UpdateCategoryResponse>
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? PhotoUrl { get; set; }
}
