using RestaurantSystem.Contracts.Entities;
using RestaurantSystem.Contracts.OrdersDetails.Commands;

namespace RestaurantSystem.Mappers;

public class OrdersDetailsMapper
{
    public static IReadOnlyCollection<OrderDetails> MapToContract(IReadOnlyCollection<DataAccess.Models.OrderDetails> items)
    {
        return items.Select(x => MapToContract(x)).ToList();
    }

    public static OrderDetails MapToContract(DataAccess.Models.OrderDetails item)
    {
        return new OrderDetails()
        {
            Id = item.ID,
            OrderID = item.OrderID,
            ProductID = item.ProductID,
            UnitPriceGross = item.UnitPriceNetto * (1 + (100 / item.VAT)),
            VAT = item.VAT,
            Quantity = item.Quantity,
            Status = item.Status,
        };
    }

    public static DataAccess.Models.OrderDetails MapToDbModel(AddOrderDetailsCommand item)
    {
        return new DataAccess.Models.OrderDetails()
        {
            OrderID = item.OrderID,
            ProductID = item.ProductID,
            Quantity = item.Quantity,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsActive = true
        };
    }
}

