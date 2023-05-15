using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    public Task<IActionResult> GetAllCategories([FromQuery] GetCategories query)
    {
        return this.Send<GetCategories, GetCategoriesResponse>(query);
    }

    [HttpGet]
    [Route("{id}")]
    public Task<IActionResult> GetCategoryById([FromRoute] int id)
    {
        var query = new GetCategoryById()
        {
            Id = id
        };
        return this.Send<GetCategoryById, GetCategoryByIdResponse>(query);
    }

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command)
    {
        return this.Send<AddCategoryCommand, AddCategoryResponse>(command);
    }

    [HttpPut]
    [Route("")]
    public Task<IActionResult> PutCategory([FromBody] UpdateCategoryCommand command)
    {
        return this.Send<UpdateCategoryCommand, UpdateCategoryResponse>(command);
    }

    [HttpDelete]
    [Route("{id}")]
    public Task<IActionResult> DeleteCategory([FromRoute] int id)
    {
        var command = new DeleteCategoryCommand()
        {
            Id = id
        };
        return this.Send<DeleteCategoryCommand, DeleteCategoryResponse>(command);
    }
}
