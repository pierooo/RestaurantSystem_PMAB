using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Orders.Commands;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Orders;

public class AddOrderCommandHandler : HandlerBase, IRequestHandler<AddOrderCommand, CommandResponse>
{
    public AddOrderCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(AddOrderCommand command, CancellationToken cancellationToken)
    {
        restaurantSystemContext.Orders.Add(OrdersMapper.MapToDbModel(command));
        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}

