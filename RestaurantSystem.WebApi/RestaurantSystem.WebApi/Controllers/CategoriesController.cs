using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Categories.Commands;
using RestaurantSystem.Contracts.Categories.Queries;
using RestaurantSystem.WebApi.Controllers.Abstract;

namespace RestaurantSystem.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ApiControllerBase
{
    public CategoriesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<GetCategoriesResponse>> GetAllCategories([FromQuery] GetCategories query)
    {
        return await this.Send<GetCategories, GetCategoriesResponse>(query);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetCategoryByIdResponse>> GetCategoryById([FromRoute] int id)
    {
        var query = new GetCategoryById()
        {
            Id = id
        };
        return await this.Send<GetCategoryById, GetCategoryByIdResponse>(query);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command)
    {
        await this.Send<AddCategoryCommand, CommandResponse>(command);
        return Ok();
    }

    [HttpPut]
    [Route("")]
    public async Task<IActionResult> PutCategory([FromBody] UpdateCategoryCommand command)
    {
        await this.Send<UpdateCategoryCommand, CommandResponse>(command);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id)
    {
        var command = new DeleteCategoryCommand()
        {
            Id = id
        };
        await this.Send<DeleteCategoryCommand, CommandResponse>(command);
        return Ok();
    }
}
