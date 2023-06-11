using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Products.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.Products;

public class UpdateProductCommandHandler : HandlerBase, IRequestHandler<UpdateProductCommand, CommandResponse>
{
    public UpdateProductCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<CommandResponse> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var item = await restaurantSystemContext.Products.FindAsync(command.Id);

        if (item == null)
        {
            throw new Exception("Entity not found: " + nameof(Products));
        }

        item.Name = command.Name;
        item.Description = command.Description;
        item.PhotoUrl = command.PhotoUrl;
        item.CategoryID = command.CategoryID;
        item.UnitPriceNetto = command.UnitPriceGross / (1 + (item.VAT / 100));
        item.VAT = command.VAT;
        item.UnitsInStock = command.UnitsInStock;
        item.UpdatedAt = DateTime.UtcNow;

        await restaurantSystemContext.SaveChangesAsync();

        return new CommandResponse();
    }
}

