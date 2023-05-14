using System.ComponentModel.DataAnnotations;

namespace RestaurantSystem.DataAccess.Models;

public abstract class EntityBase
{
    [Key]
    public int ID { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Notes { get; set; }

    public bool IsActive { get; set; }
}
