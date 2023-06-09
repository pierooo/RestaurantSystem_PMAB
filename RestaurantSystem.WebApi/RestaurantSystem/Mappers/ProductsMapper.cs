using RestaurantSystem.Contracts.Entities;
using RestaurantSystem.Contracts.Products.Commands;

namespace RestaurantSystem.Mappers;

public static class ProductsMapper
{
    public static IReadOnlyCollection<Product>? MapToContract(IReadOnlyCollection<DataAccess.Models.Product>? items)
    {
        return items?.Select(x => MapToContract(x)).ToList();
    }

    public static Product MapToContract(DataAccess.Models.Product? item)
    {
        return item == null ? throw new Exception("Entity not found") : new Product()
        {
            Id = item.ID,
            Name = item.Name,
            Description = item.Description,
            PhotoUrl = item.PhotoUrl,
            CategoryID = item.CategoryID,
            UnitPriceGross = item.UnitPriceNetto * (1 + (item.VAT / 100)),
            VAT = item.VAT,
            UnitsInStock = item.UnitsInStock
        };
    }

    public static DataAccess.Models.Product MapToDbModel(AddProductCommand item)
    {
        return new DataAccess.Models.Product()
        {
            Name = item.Name,
            Description = item.Description,
            PhotoUrl = item.PhotoUrl,
            CategoryID = item.CategoryID,
            UnitPriceNetto = item.UnitPriceGross / (1 + (item.VAT / 100)),
            VAT = item.VAT,
            UnitsInStock = item.UnitsInStock,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsActive = true
        };
    }
}

