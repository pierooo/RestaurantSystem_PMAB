using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.OrdersDetails.Commands;
using RestaurantSystem.Contracts.OrdersDetails.Queries;
using RestaurantSystem.WebApi.Controllers.Abstract;

namespace RestaurantSystem.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersDetailsController : ApiControllerBase
{
    public OrdersDetailsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("order/{orderId}")]
    public async Task<ActionResult<GetOrdersDetailsByOrderIdResponse>> GetAllOrdersDetailsByOrderId([FromRoute] int orderId)
    {
        var query = new GetOrdersDetailsByOrderId()
        {
            OrderId = orderId
        };
        return await this.Send<GetOrdersDetailsByOrderId, GetOrdersDetailsByOrderIdResponse>(query);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetOrderDetailsByIdResponse>> GetOrderDetailsById([FromRoute] int id)
    {
        var query = new GetOrderDetailsById()
        {
            Id = id
        };
        return await this.Send<GetOrderDetailsById, GetOrderDetailsByIdResponse>(query);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddOrderDetails([FromBody] AddOrderDetailsCommand command)
    {
        await this.Send<AddOrderDetailsCommand, CommandResponse>(command);
        return Ok();
    }

    [HttpPut]
    [Route("")]
    public async Task<IActionResult> PutOrderDetails([FromBody] UpdateOrderDetailsCommand command)
    {
        await this.Send<UpdateOrderDetailsCommand, CommandResponse>(command);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteOrderDetails([FromRoute] int id)
    {
        var command = new DeleteOrderDetailsCommand()
        {
            Id = id
        };
        await this.Send<DeleteOrderDetailsCommand, CommandResponse>(command);
        return Ok();
    }
}
