using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.Categories.Queries;

public class GetCategoriesResponse : IResponseBase
{
    public IReadOnlyCollection<Category>? Categories { get; set; }
}