using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Entities;
using RestaurantSystem.Contracts.Products.Commands;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;

namespace RestaurantSystem.Handlers.Products;

public class AddProductCommandHandler : HandlerBase, IRequestHandler<AddProductCommand, AddProductResponse>
{
    public AddProductCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
    {
    }

    public async Task<AddProductResponse> Handle(AddProductCommand command, CancellationToken cancellationToken)
    {
        try
        {
            RestaurantSystemContext.Products.Add(ProductsMapper.MapToDbModel(command));
            await RestaurantSystemContext.SaveChangesAsync();
            return new AddProductResponse()
            {
                Data = new CommandResponse(true)
            };
        }
        catch (Exception ex)
        {
            return new AddProductResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound + ": " + nameof(Category))
            };
        }
    }
}


