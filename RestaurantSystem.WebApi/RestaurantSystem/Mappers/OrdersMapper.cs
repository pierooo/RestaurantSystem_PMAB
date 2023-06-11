using RestaurantSystem.Contracts.Entities;
using RestaurantSystem.Contracts.Orders.Commands;

namespace RestaurantSystem.Mappers;

public class OrdersMapper
{
    public static IReadOnlyCollection<Order>? MapToContract(IReadOnlyCollection<DataAccess.Models.Order>? items)
    {
        return items?.Select(x => MapToContract(x)).ToList();
    }

    public static Order MapToContract(DataAccess.Models.Order? item)
    {
        return item == null ? throw new Exception("Entity not found") : new Order()
        {
            Id = item.ID,
            Description = item.Description,
            RestaurantTableID = item.RestaurantTableID,
            OrderDate = item.OrderDate,
            Status = item.Status,
            TotalPriceGross = item.TotalPriceGross,
        };
    }

    public static DataAccess.Models.Order MapToDbModel(AddOrderCommand item)
    {
        return new DataAccess.Models.Order()
        {
            Description = item.Description,
            RestaurantTableID = item.RestaurantTableID,
            TotalPriceGross = 0m,
            OrderDate = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsActive = true
        };
    }
}
