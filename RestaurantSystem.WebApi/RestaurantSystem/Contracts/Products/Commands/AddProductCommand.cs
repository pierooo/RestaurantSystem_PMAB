using MediatR;

namespace RestaurantSystem.Contracts.Products.Commands;

public class AddProductCommand : IRequest<CommandResponse>
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? PhotoUrl { get; set; }

    public int CategoryID { get; set; }

    public decimal UnitPriceGross { get; set; }

    public int VAT { get; set; }

    public int UnitsInStock { get; set; }
}
