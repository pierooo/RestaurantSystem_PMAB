using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.RestaurantTables.Commands;
using RestaurantSystem.Contracts.RestaurantTables.Queries;
using RestaurantSystem.WebApi.Controllers.Abstract;

namespace RestaurantSystem.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RestaurantTablesController : ApiControllerBase
{
    public RestaurantTablesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<GetRestaurantTablesResponse>> GetAllRestaurantTables([FromQuery] GetRestaurantTables query)
    {
        return await this.Send<GetRestaurantTables, GetRestaurantTablesResponse>(query);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetRestaurantTableByIdResponse>> GetRestaurantTableById([FromRoute] int id)
    {
        var query = new GetRestaurantTableById()
        {
            Id = id
        };
        return await this.Send<GetRestaurantTableById, GetRestaurantTableByIdResponse>(query);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddRestaurantTable([FromBody] AddRestaurantTableCommand command)
    {
        await this.Send<AddRestaurantTableCommand, CommandResponse>(command);
        return Ok();
    }

    [HttpPut]
    [Route("")]
    public async Task<IActionResult> PutRestaurantTable([FromBody] UpdateRestaurantTableCommand command)
    {
        await this.Send<UpdateRestaurantTableCommand, CommandResponse>(command);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteRestaurantTable([FromRoute] int id)
    {
        var command = new DeleteRestaurantTableCommand()
        {
            Id = id
        };
        await this.Send<DeleteRestaurantTableCommand, CommandResponse>(command);
        return Ok();
    }
}