using MediatR;

namespace RestaurantSystem.Contracts.Products.Commands;

public class DeleteProductCommand : IRequest<CommandResponse>
{
    public int Id { get; set; }
}
