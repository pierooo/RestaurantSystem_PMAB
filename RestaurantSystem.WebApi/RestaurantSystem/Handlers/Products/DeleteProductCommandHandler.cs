using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Products.Commands;
using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers.Products;

public class DeleteProductCommandHandler : HandlerBase, IRequestHandler<DeleteProductCommand, DeleteProductResponse>
{
    public DeleteProductCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<DeleteProductResponse> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var item = await RestaurantSystemContext.Products.FindAsync(command.Id);

            if (item == null)
            {
                return new DeleteProductResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            item.IsActive = false;

            await RestaurantSystemContext.SaveChangesAsync();

            return new DeleteProductResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new DeleteProductResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
    }
}

