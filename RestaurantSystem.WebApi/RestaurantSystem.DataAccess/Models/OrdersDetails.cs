using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantSystem.DataAccess.Models
{
    public class OrderDetails : EntityBase
    {
        public Order? Order { get; set; }

        public int OrderID { get; set; }

        public Product? Product { get; set; }

        public int ProductID { get; set; }

        [Column(TypeName = "Money")]
        public decimal UnitPriceNetto { get; set; }

        public int VAT { get; set; }

        public int Quantity { get; set; }

        public string? Status { get; set; }
    }
}
