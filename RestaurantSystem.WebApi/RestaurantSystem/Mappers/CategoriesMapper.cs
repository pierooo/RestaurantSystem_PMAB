using RestaurantSystem.Contracts.Categories.Commands;
using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Mappers;

public static class CategoriesMapper
{
    public static IReadOnlyCollection<Category>? MapToContract(IReadOnlyCollection<DataAccess.Models.Category>? categories)
    {
        return categories?.Select(x => MapToContract(x)).ToList();
    }

    public static Category MapToContract(DataAccess.Models.Category? category)
    {
        return category == null ? throw new Exception("Entity not found") : new Category()
        {
            Id = category.ID,
            Name = category.Name,
            Description = category.Description,
            PhotoUrl = category.PhotoUrl
        };
    }

    public static DataAccess.Models.Category MapToDbModel(AddCategoryCommand category)
    {
        return new DataAccess.Models.Category()
        {
            Name = category.Name,
            Description = category.Description,
            PhotoUrl = category.PhotoUrl,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsActive = true
        };
    }
}
