using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.Categories.Queries;

public class GetCategoriesResponse : ResponseBase<IReadOnlyCollection<Category>>
{
}