namespace RestaurantSystem.Contracts.Entities;

public class Reservation
{
    public int Id { get; set; }

    public int RestaurantTableId { get; set; }

    public DateTime ReservationDate { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }
}
