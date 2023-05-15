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
    public Task<IActionResult> GetAllOrders([FromQuery] GetOrders request)
    {
        return this.Send<GetOrders, GetOrdersResponse>(request);
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
    public Task<IActionResult> PutOrder([FromBody] UpdateOrderCommand request)
    {
        return this.Send<UpdateOrderCommand, UpdateOrderResponse>(request);
    }

    [HttpDelete]
    [Route("{id}")]
    public Task<IActionResult> DeleteOrder([FromRoute] int id)
    {
        var request = new DeleteOrderCommand()
        {
            Id = id
        };
        return this.Send<DeleteOrderCommand, DeleteOrderResponse>(request);
    }
}