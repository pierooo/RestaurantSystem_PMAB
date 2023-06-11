using RestaurantSystem.Contracts.Entities;
using RestaurantSystem.Contracts.RestaurantTables.Commands;

namespace RestaurantSystem.Mappers;

public static class RestaurantTablesMapper
{
    public static IReadOnlyCollection<RestaurantTable>? MapToContract(IReadOnlyCollection<DataAccess.Models.RestaurantTable>? items)
    {
        return items?.Select(x => MapToContract(x)).ToList();
    }

    public static RestaurantTable MapToContract(DataAccess.Models.RestaurantTable? item)
    {
        return item == null ? throw new Exception("Entity not found") : new RestaurantTable()
        {
            Id = item.ID,
            Name = item.Name,
            Description = item.Description,
            PhotoUrl = item.PhotoUrl,
            MaxCapacity = item.MaxCapacity
        };
    }

    public static DataAccess.Models.RestaurantTable MapToDbModel(AddRestaurantTableCommand item)
    {
        return new DataAccess.Models.RestaurantTable()
        {
            Name = item.Name,
            Description = item.Description,
            PhotoUrl = item.PhotoUrl,
            MaxCapacity = item.MaxCapacity,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsActive = true
        };
    }
}
