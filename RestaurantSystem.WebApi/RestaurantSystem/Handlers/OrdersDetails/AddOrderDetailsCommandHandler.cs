using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Entities;
using RestaurantSystem.Contracts.OrdersDetails.Commands;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.OrdersDetails;

public class AddOrderDetailsCommandHandler : HandlerBase, IRequestHandler<AddOrderDetailsCommand, AddOrderDetailsResponse>
{
    public AddOrderDetailsCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<AddOrderDetailsResponse> Handle(AddOrderDetailsCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var item = await RestaurantSystemContext.Orders.FindAsync(command.OrderID);

            if (item == null)
            {
                return new AddOrderDetailsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var orderDetails = OrdersDetailsMapper.MapToDbModel(command);
            var product = await RestaurantSystemContext.Products.SingleAsync(x => x.ID == orderDetails.ProductID);

            orderDetails.UnitPriceNetto = product.UnitPriceNetto;
            orderDetails.VAT = product.VAT;

            RestaurantSystemContext.OrdersDetails.Add(orderDetails);
            await RestaurantSystemContext.SaveChangesAsync();
            return new AddOrderDetailsResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new AddOrderDetailsResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ": " + nameof(Product))
            };
        }
    }
}