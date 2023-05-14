using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantSystem.DataAccess.Models;

public class Order : EntityBase
{
    public RestaurantTable? RestaurantTable { get; set; }

    public int RestaurantTableID { get; set; }

    public List<OrderDetails>? OrdersDetails { get; set; }

    public DateTime OrderDate { get; set; }

    [Column(TypeName = "Money")]
    public decimal TotalPriceGross { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }
}
