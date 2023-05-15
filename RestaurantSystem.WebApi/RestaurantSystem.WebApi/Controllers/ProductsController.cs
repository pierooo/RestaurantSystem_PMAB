using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Contracts.Products.Commands;
using RestaurantSystem.Contracts.Products.Queries;
using RestaurantSystem.Contracts.Reservations.Commands;
using RestaurantSystem.Contracts.Reservations.Queries;
using RestaurantSystem.WebApi.Controllers.Abstract;

namespace RestaurantSystem.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ApiControllerBase
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllProducts([FromQuery] GetProducts request)
    {
        return this.Send<GetProducts, GetProductsResponse>(request);
    }

    [HttpGet]
    [Route("{id}")]
    public Task<IActionResult> GetProductById([FromRoute] int id)
    {
        var query = new GetProductById()
        {
            Id = id
        };
        return this.Send<GetProductById, GetProductByIdResponse>(query);
    }

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
    {
        return this.Send<AddProductCommand, AddProductResponse>(command);
    }

    [HttpPut]
    [Route("")]
    public Task<IActionResult> PutProduct([FromBody] UpdateProductCommand request)
    {
        return this.Send<UpdateProductCommand, UpdateProductResponse>(request);
    }

    [HttpDelete]
    [Route("{id}")]
    public Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
        var request = new DeleteProductCommand()
        {
            Id = id
        };
        return this.Send<DeleteProductCommand, DeleteProductResponse>(request);
    }
}

