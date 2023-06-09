using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Products.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.Products;

public class DeleteProductCommandHandler : HandlerBase, IRequestHandler<DeleteProductCommand, CommandResponse>
{
    public DeleteProductCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var item = await restaurantSystemContext.Products.FindAsync(command.Id);

        if (item == null)
        {
            throw new Exception("Entity not found: " + nameof(Products));
        }

        item.IsActive = false;

        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}

