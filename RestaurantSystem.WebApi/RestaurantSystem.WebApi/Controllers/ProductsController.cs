using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Products.Commands;
using RestaurantSystem.Contracts.Products.Queries;
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
    public async Task<ActionResult<GetProductsResponse>> GetAllProducts([FromQuery] GetProducts query)
    {
        return await this.Send<GetProducts, GetProductsResponse>(query);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetProductByIdResponse>> GetProductById([FromRoute] int id)
    {
        var query = new GetProductById()
        {
            Id = id
        };
        return await this.Send<GetProductById, GetProductByIdResponse>(query);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
    {
        await this.Send<AddProductCommand, CommandResponse>(command);
        return Ok();
    }

    [HttpPut]
    [Route("")]
    public async Task<IActionResult> PutProduct([FromBody] UpdateProductCommand command)
    {
        await this.Send<UpdateProductCommand, CommandResponse>(command);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
        var command = new DeleteProductCommand()
        {
            Id = id
        };
        await this.Send<DeleteProductCommand, CommandResponse>(command);
        return Ok();
    }
}

