using System.ComponentModel.DataAnnotations;

namespace RestaurantSystem.DataAccess.Models;

public class RestaurantTable : EntityBase
{
    [Required]
    [MaxLength(150)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public int MaxCapacity { get; set; }

    public string? PhotoUrl { get; set; }

    public List<Order>? Orders { get; set; }

    public List<Reservation>? Reservations { get; set; }
}
