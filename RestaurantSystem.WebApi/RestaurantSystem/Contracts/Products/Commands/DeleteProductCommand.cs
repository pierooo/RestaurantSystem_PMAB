using MediatR;

namespace RestaurantSystem.Contracts.Products.Commands;

public class DeleteProductCommand : IRequest<DeleteProductResponse>
{
    public int Id { get; set; }
}
