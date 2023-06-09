using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.Categories.Queries;

public class GetCategoryByIdResponse : IResponseBase
{
    public Category? Category { get; set; }
}