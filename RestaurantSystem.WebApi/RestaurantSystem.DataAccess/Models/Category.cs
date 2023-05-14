using System.ComponentModel.DataAnnotations;

namespace RestaurantSystem.DataAccess.Models;

public class Category : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public string? PhotoUrl { get; set; }

    public List<Product>? Products { get; set; }
}
