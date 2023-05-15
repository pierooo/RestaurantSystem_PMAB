using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    public Task<IActionResult> GetAllOrdersDetailsByOrderId([FromRoute] int orderId)
    {
        var query = new GetOrdersDetailsByOrderId()
        {
            OrderId = orderId
        };
        return this.Send<GetOrdersDetailsByOrderId, GetOrdersDetailsByOrderIdResponse>(query);
    }

    [HttpGet]
    [Route("{id}")]
    public Task<IActionResult> GetOrderDetailsById([FromRoute] int id)
    {
        var query = new GetOrderDetailsById()
        {
            Id = id
        };
        return this.Send<GetOrderDetailsById, GetOrderDetailsByIdResponse>(query);
    }

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddOrderDetails([FromBody] AddOrderDetailsCommand command)
    {
        return this.Send<AddOrderDetailsCommand, AddOrderDetailsResponse>(command);
    }

    [HttpPut]
    [Route("")]
    public Task<IActionResult> PutOrderDetails([FromBody] UpdateOrderDetailsCommand command)
    {
        return this.Send<UpdateOrderDetailsCommand, UpdateOrderDetailsResponse>(command);
    }

    [HttpDelete]
    [Route("{id}")]
    public Task<IActionResult> DeleteOrderDetails([FromRoute] int id)
    {
        var command = new DeleteOrderDetailsCommand()
        {
            Id = id
        };
        return this.Send<DeleteOrderDetailsCommand, DeleteOrderDetailsResponse>(command);
    }
}
