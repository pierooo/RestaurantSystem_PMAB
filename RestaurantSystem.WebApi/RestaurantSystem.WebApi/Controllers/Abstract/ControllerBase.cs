using System.Net;
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

    protected async Task<IActionResult> Send<TRequest, TResponse>(TRequest query)
        where TRequest : IRequest<TResponse>
        where TResponse : ErrorResponseBase

    {
        if (!this.ModelState.IsValid)
        {
            return this.BadRequest(
                           this.ModelState
                                .Where(x => x.Value.Errors.Any())
                                .Select(x => new { property = x.Key, errors = x.Value.Errors }));
        }

        var response = await this.mediator.Send(query);

        if (response.Error != null)
        {
            return this.ErrorResponse(response.Error);
        }

        return this.Ok(response);
    }

    private IActionResult ErrorResponse(ErrorModel errorModel)
    {
        var httpCode = GetHttpStatusCode(errorModel.Error);
        return StatusCode((int)httpCode, errorModel);
    }

    private static HttpStatusCode GetHttpStatusCode(string error)
    {
        return error switch
        {
            ErrorType.NotFound => HttpStatusCode.NotFound,
            ErrorType.InternalServerError => HttpStatusCode.InternalServerError,
            ErrorType.Unautorized => HttpStatusCode.Unauthorized,
            ErrorType.RequestTooLarge => HttpStatusCode.RequestEntityTooLarge,
            ErrorType.UnSupportedMediaType => HttpStatusCode.UnsupportedMediaType,
            ErrorType.UnSupportedMethod => HttpStatusCode.MethodNotAllowed,
            ErrorType.TooManyRequest => HttpStatusCode.TooManyRequests,
            _ => HttpStatusCode.BadRequest,
        };
    }
}

