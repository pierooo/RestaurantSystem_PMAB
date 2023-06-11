using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.Products.Queries;

public class GetProductsResponse : IResponseBase
{
    public IReadOnlyCollection<Product>? Products { get; set; }
}
