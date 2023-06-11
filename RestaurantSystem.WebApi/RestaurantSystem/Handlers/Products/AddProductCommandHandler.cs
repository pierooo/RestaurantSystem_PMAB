using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Products.Commands;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Products;

public class AddProductCommandHandler : HandlerBase, IRequestHandler<AddProductCommand, CommandResponse>
{
    public AddProductCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(AddProductCommand command, CancellationToken cancellationToken)
    {
        restaurantSystemContext.Products.Add(ProductsMapper.MapToDbModel(command));
        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}


