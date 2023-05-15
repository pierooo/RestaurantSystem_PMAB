using MediatR;

namespace RestaurantSystem.Contracts.OrdersDetails.Commands;

public class UpdateOrderDetailsCommand : IRequest<UpdateOrderDetailsResponse>
{
    public int Id { get; set; }

    public int ProductID { get; set; }

    public int Quantity { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }
}
