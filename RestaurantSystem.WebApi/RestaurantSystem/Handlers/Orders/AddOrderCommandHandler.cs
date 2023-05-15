using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Entities;
using RestaurantSystem.Contracts.Orders.Commands;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Orders;

public class AddOrderCommandHandler : HandlerBase, IRequestHandler<AddOrderCommand, AddOrderResponse>
{
    public AddOrderCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<AddOrderResponse> Handle(AddOrderCommand command, CancellationToken cancellationToken)
    {
        try
        {
            RestaurantSystemContext.Orders.Add(OrdersMapper.MapToDbModel(command));
            await RestaurantSystemContext.SaveChangesAsync();
            return new AddOrderResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new AddOrderResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ": " + nameof(RestaurantTable))
            };
        }
    }
}

