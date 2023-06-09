using MediatR;

namespace RestaurantSystem.Contracts.Categories.Commands;

public class AddCategoryCommand : IRequest<CommandResponse>
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? PhotoUrl { get; set; }
}