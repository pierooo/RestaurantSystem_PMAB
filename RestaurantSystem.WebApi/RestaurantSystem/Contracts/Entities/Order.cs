namespace RestaurantSystem.Contracts.Entities;

public class Order
{
    public int Id { get; set; }

    public int RestaurantTableID { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalPriceGross { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }
}
