using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Entities;
using RestaurantSystem.Contracts.Products.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.Products;

public class UpdateProductCommandHandler : HandlerBase, IRequestHandler<UpdateProductCommand, UpdateProductResponse>
{
    public UpdateProductCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<UpdateProductResponse> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var item = await RestaurantSystemContext.Products.FindAsync(command.Id);

            if (item == null)
            {
                return new UpdateProductResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            item.Name = command.Name;
            item.Description = command.Description;
            item.PhotoUrl = command.PhotoUrl;
            item.CategoryID = command.CategoryID;
            item.UnitPriceNetto = command.UnitPriceGross / (1 + (item.VAT / 100));
            item.VAT = command.VAT;
            item.UnitsInStock = command.UnitsInStock;
            item.UpdatedAt = DateTime.UtcNow;

            await RestaurantSystemContext.SaveChangesAsync();

            return new UpdateProductResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new UpdateProductResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ": " + nameof(Category))
            };
        }
    }
}

