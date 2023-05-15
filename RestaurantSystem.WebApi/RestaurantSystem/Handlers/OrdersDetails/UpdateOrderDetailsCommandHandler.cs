﻿using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Entities;
using RestaurantSystem.Contracts.OrdersDetails.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.OrdersDetails;

public class UpdateOrderDetailsCommandHandler : HandlerBase, IRequestHandler<UpdateOrderDetailsCommand, UpdateOrderDetailsResponse>
{
    public UpdateOrderDetailsCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<UpdateOrderDetailsResponse> Handle(UpdateOrderDetailsCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var item = await RestaurantSystemContext.OrdersDetails.FindAsync(command.Id);

            if (item == null)
            {
                return new UpdateOrderDetailsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var order = await RestaurantSystemContext.Orders.FindAsync(item.OrderID);

            if (order == null)
            {
                return new UpdateOrderDetailsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound + ": " + nameof(Order))
                };
            }

            order.TotalPriceGross -= (item.UnitPriceNetto * (1 + (100 / item.VAT))) * item.Quantity;

            item.ProductID = command.ProductID;
            item.Quantity = command.Quantity;
            item.Notes = command.Notes;
            item.Status = command.Status;
            item.UpdatedAt = DateTime.UtcNow;

            if (command.ProductID != item.ProductID)
            {
                var product = await RestaurantSystemContext.Products.FindAsync(command.ProductID);

                if (product == null)
                {
                    return new UpdateOrderDetailsResponse()
                    {
                        Error = new ErrorModel(ErrorType.NotFound + ": " + nameof(Product))
                    };
                }

                item.UnitPriceNetto = product.UnitPriceNetto;
            }

            order.TotalPriceGross += (item.UnitPriceNetto * (1 + (item.VAT / 100))) * item.Quantity;

            await RestaurantSystemContext.SaveChangesAsync();

            return new UpdateOrderDetailsResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new UpdateOrderDetailsResponse()
            {
                Error = new ErrorModel(ex.Message)
            };
        }
    }
}
