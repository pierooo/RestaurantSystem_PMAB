using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Contracts;

namespace RestaurantSystem.WebApi.Controllers.Abstract;

public class ApiControllerBase : Controller
{
    protected readonly IMediator mediator;

    protected ApiControllerBase(IMediator mediator)
    {
        this.mediator = mediator;
    }

    protected async Task<ActionResult<TResponse>> Send<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
        where TResponse : IResponseBase
    {
        if (!this.ModelState.IsValid)
        {
            return this.BadRequest(
                           this.ModelState
                                .Where(x => x.Value.Errors.Any())
                                .Select(x => new { property = x.Key, errors = x.Value.Errors }));
        }

        var response = await this.mediator.Send(request);

        if(response == null)
        {
            return NotFound();
        }

        return response;
    }
}

