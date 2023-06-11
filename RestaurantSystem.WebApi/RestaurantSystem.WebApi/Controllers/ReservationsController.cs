using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Reservations.Commands;
using RestaurantSystem.Contracts.Reservations.Queries;
using RestaurantSystem.WebApi.Controllers.Abstract;

namespace RestaurantSystem.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservationsController : ApiControllerBase
{
    public ReservationsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<GetReservationsResponse>> GetAllReservations([FromQuery] GetReservations query)
    {
        return await this.Send<GetReservations, GetReservationsResponse>(query);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetReservationByIdResponse>> GetReservationById([FromRoute] int id)
    {
        var query = new GetReservationById()
        {
            Id = id
        };
        return await this.Send<GetReservationById, GetReservationByIdResponse>(query);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddReservation([FromBody] AddReservationCommand command)
    {
        await this.Send<AddReservationCommand, CommandResponse>(command);
        return Ok();
    }

    [HttpPut]
    [Route("")]
    public async Task<IActionResult> PutReservation([FromBody] UpdateReservationCommand command)
    {
        await this.Send<UpdateReservationCommand, CommandResponse>(command);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteReservation([FromRoute] int id)
    {
        var command = new DeleteReservationCommand()
        {
            Id = id
        };
        await this.Send<DeleteReservationCommand, CommandResponse>(command);
        return Ok();
    }
}
