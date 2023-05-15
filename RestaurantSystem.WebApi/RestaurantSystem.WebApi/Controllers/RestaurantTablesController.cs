﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Contracts.RestaurantTables.Commands;
using RestaurantSystem.Contracts.RestaurantTables.Queries;
using RestaurantSystem.WebApi.Controllers.Abstract;

namespace RestaurantSystem.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RestaurantTablesController : ApiControllerBase
{
    protected RestaurantTablesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllRestaurantTables([FromQuery] GetRestaurantTables request)
    {
        return this.Send<GetRestaurantTables, GetRestaurantTablesResponse>(request);
    }

    [HttpGet]
    [Route("{id}")]
    public Task<IActionResult> GetRestaurantTableById([FromRoute] int id)
    {
        var query = new GetRestaurantTableById()
        {
            Id = id
        };
        return this.Send<GetRestaurantTableById, GetRestaurantTableByIdResponse>(query);
    }

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddRestaurantTable([FromBody] AddRestaurantTableCommand command)
    {
        return this.Send<AddRestaurantTableCommand, AddRestaurantTableResponse>(command);
    }

    [HttpPut]
    [Route("")]
    public Task<IActionResult> PutRestaurantTable([FromBody] UpdateRestaurantTableCommand request)
    {
        return this.Send<UpdateRestaurantTableCommand, UpdateRestaurantTableResponse>(request);
    }

    [HttpDelete]
    [Route("{id}")]
    public Task<IActionResult> DeleteRestaurantTable([FromRoute] int id)
    {
        var request = new DeleteRestaurantTableCommand()
        {
            Id = id
        };
        return this.Send<DeleteRestaurantTableCommand, DeleteRestaurantTableResponse>(request);
    }
}