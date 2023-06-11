using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Orders.Commands;
using RestaurantSystem.Contracts.Orders.Queries;
using RestaurantSystem.WebApi.Controllers.Abstract;

namespace RestaurantSystem.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ApiControllerBase
{
    public OrdersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<GetOrdersResponse>> GetAllOrders([FromQuery] GetOrders query)
    {
        return await this.Send<GetOrders, GetOrdersResponse>(query);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetOrderByIdResponse>> GetOrderById([FromRoute] int id)
    {
        var query = new GetOrderById()
        {
            Id = id
        };
        return await this.Send<GetOrderById, GetOrderByIdResponse>(query);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddOrder([FromBody] AddOrderCommand command)
    {
        await this.Send<AddOrderCommand, CommandResponse>(command);
        return Ok();
    }

    [HttpPut]
    [Route("")]
    public async Task<IActionResult> PutOrder([FromBody] UpdateOrderCommand command)
    {
        await this.Send<UpdateOrderCommand, CommandResponse>(command);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteOrder([FromRoute] int id)
    {
        var command = new DeleteOrderCommand()
        {
            Id = id
        };
        await this.Send<DeleteOrderCommand, CommandResponse>(command);
        return Ok();
    }
}