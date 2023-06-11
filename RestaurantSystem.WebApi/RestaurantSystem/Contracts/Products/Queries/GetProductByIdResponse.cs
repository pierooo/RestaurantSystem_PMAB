using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.Products.Queries;

public class GetProductByIdResponse : IResponseBase
{
    public Product? Product { get; set; }
}
