namespace RestaurantSystem.Contracts.Entities;

public class OrderDetails
{
    public int Id { get; set; }

    public int OrderID { get; set; }

    public int ProductID { get; set; }

    public decimal UnitPriceGross { get; set; }

    public int VAT { get; set; }

    public int Quantity { get; set; }

    public string? Status { get; set; }
}
