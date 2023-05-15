using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    public Task<IActionResult> GetAllOrders([FromQuery] GetOrders query)
    {
        return this.Send<GetOrders, GetOrdersResponse>(query);
    }

    [HttpGet]
    [Route("{id}")]
    public Task<IActionResult> GetOrderById([FromRoute] int id)
    {
        var query = new GetOrderById()
        {
            Id = id
        };
        return this.Send<GetOrderById, GetOrderByIdResponse>(query);
    }

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddOrder([FromBody] AddOrderCommand command)
    {
        return this.Send<AddOrderCommand, AddOrderResponse>(command);
    }

    [HttpPut]
    [Route("")]
    public Task<IActionResult> PutOrder([FromBody] UpdateOrderCommand command)
    {
        return this.Send<UpdateOrderCommand, UpdateOrderResponse>(command);
    }

    [HttpDelete]
    [Route("{id}")]
    public Task<IActionResult> DeleteOrder([FromRoute] int id)
    {
        var command = new DeleteOrderCommand()
        {
            Id = id
        };
        return this.Send<DeleteOrderCommand, DeleteOrderResponse>(command);
    }
}