using MediatR;

namespace RestaurantSystem.Contracts.Products.Queries;

public class GetProductById : IRequest<GetProductByIdResponse>
{
    public int Id { get; set; }
}
