using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantSystem.DataAccess.Models;

public class Product : EntityBase
{
    [Required]
    [MaxLength(250)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? PhotoUrl { get; set; }

    public Category? Category { get; set; }

    public int CategoryID { get; set; }

    [Column(TypeName = "Money")]
    public decimal UnitPriceNetto { get; set; }

    public int VAT { get; set; }

    public int UnitsInStock { get; set; }
}
