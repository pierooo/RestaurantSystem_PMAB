using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.OrdersDetails.Commands;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.OrdersDetails;

public class AddOrderDetailsCommandHandler : HandlerBase, IRequestHandler<AddOrderDetailsCommand, CommandResponse>
{
    public AddOrderDetailsCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(AddOrderDetailsCommand command, CancellationToken cancellationToken)
    {
        var order = await restaurantSystemContext.Orders.FindAsync(command.OrderID);

        if (order == null)
        {
            throw new Exception("Entity not found: " + nameof(Orders));
        }

        var orderDetails = OrdersDetailsMapper.MapToDbModel(command);
        var product = await restaurantSystemContext.Products.SingleAsync(x => x.ID == orderDetails.ProductID);

        if (order == null)
        {
            throw new Exception("Entity not found: " + nameof(Products));
        }

        orderDetails.UnitPriceNetto = product.UnitPriceNetto;
        orderDetails.VAT = product.VAT;

        restaurantSystemContext.OrdersDetails.Add(orderDetails);

        order.TotalPriceGross += (orderDetails.UnitPriceNetto * (1 + (orderDetails.VAT / 100))) * orderDetails.Quantity;

        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}