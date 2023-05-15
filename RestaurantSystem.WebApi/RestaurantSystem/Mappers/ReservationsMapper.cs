using RestaurantSystem.Contracts.Categories.Commands;
using RestaurantSystem.Contracts.Entities;
using RestaurantSystem.Contracts.Reservations.Commands;

namespace RestaurantSystem.Mappers;

public static class ReservationsMapper
{
    public static IReadOnlyCollection<Reservation> MapToContract(IReadOnlyCollection<DataAccess.Models.Reservation> items)
    {
        return items.Select(x => MapToContract(x)).ToList();
    }

    public static Reservation MapToContract(DataAccess.Models.Reservation item)
    {
        return new Reservation()
        {
            Id = item.ID,
            ReservationDate = item.ReservationDate,
            Description = item.Description,
            Status = item.Status,
            RestaurantTableId = item.RestaurantTableId
        };
    }

    public static DataAccess.Models.Reservation MapToDbModel(AddReservationCommand item)
    {
        return new DataAccess.Models.Reservation()
        {
            ReservationDate = item.ReservationDate,
            Description = item.Description,
            Status = item.Status,
            RestaurantTableId = item.RestaurantTableId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsActive = true
        };
    }
}
