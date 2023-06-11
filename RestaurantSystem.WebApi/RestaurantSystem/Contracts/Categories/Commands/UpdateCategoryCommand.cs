using MediatR;

namespace RestaurantSystem.Contracts.Categories.Commands;

public class UpdateCategoryCommand : IRequest<CommandResponse>
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? PhotoUrl { get; set; }
}
