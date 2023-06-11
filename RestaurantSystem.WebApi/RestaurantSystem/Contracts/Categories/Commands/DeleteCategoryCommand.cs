using MediatR;

namespace RestaurantSystem.Contracts.Categories.Commands;

public class DeleteCategoryCommand : IRequest<CommandResponse>
{
    public int Id { get; set; }
}
