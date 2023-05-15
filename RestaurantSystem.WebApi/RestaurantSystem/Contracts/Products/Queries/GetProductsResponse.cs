using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.Products.Queries;

public class GetProductsResponse : ResponseBase<IReadOnlyCollection<Product>>
{
}
