using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.OrdersDetails.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.OrdersDetails;

public class UpdateOrderDetailsCommandHandler : HandlerBase, IRequestHandler<UpdateOrderDetailsCommand, CommandResponse>
{
    public UpdateOrderDetailsCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(UpdateOrderDetailsCommand command, CancellationToken cancellationToken)
    {

        var item = await restaurantSystemContext.OrdersDetails.FindAsync(command.Id);

        if (item == null)
        {
            throw new Exception("Entity not found: " + nameof(OrdersDetails));
        }

        var order = await restaurantSystemContext.Orders.FindAsync(item.OrderID);

        if (order == null)
        {
            throw new Exception("Entity not found: " + nameof(Orders));
        }

        order.TotalPriceGross -= (item.UnitPriceNetto * (1 + (100 / item.VAT))) * item.Quantity;

        item.ProductID = command.ProductID;
        item.Quantity = command.Quantity;
        item.Notes = command.Notes;
        item.Status = command.Status;
        item.UpdatedAt = DateTime.UtcNow;

        if (command.ProductID != item.ProductID)
        {
            var product = await restaurantSystemContext.Products.FindAsync(command.ProductID);

            if (product == null)
            {
                throw new Exception("Entity not found: " + nameof(Products));
            }

            item.UnitPriceNetto = product.UnitPriceNetto;
        }

        order.TotalPriceGross += (item.UnitPriceNetto * (1 + (item.VAT / 100))) * item.Quantity;

        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}
