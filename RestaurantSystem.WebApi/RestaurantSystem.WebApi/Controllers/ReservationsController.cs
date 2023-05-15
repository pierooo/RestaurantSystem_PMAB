using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    public Task<IActionResult> GetAllReservations([FromQuery] GetReservations request)
    {
        return this.Send<GetReservations, GetReservationsResponse>(request);
    }

    [HttpGet]
    [Route("{id}")]
    public Task<IActionResult> GetReservationById([FromRoute] int id)
    {
        var query = new GetReservationById()
        {
            Id = id
        };
        return this.Send<GetReservationById, GetReservationByIdResponse>(query);
    }

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddReservation([FromBody] AddReservationCommand command)
    {
        return this.Send<AddReservationCommand, AddReservationResponse>(command);
    }

    [HttpPut]
    [Route("")]
    public Task<IActionResult> PutReservation([FromBody] UpdateReservationCommand request)
    {
        return this.Send<UpdateReservationCommand, UpdateReservationResponse>(request);
    }

    [HttpDelete]
    [Route("{id}")]
    public Task<IActionResult> DeleteReservation([FromRoute] int id)
    {
        var request = new DeleteReservationCommand()
        {
            Id = id
        };
        return this.Send<DeleteReservationCommand, DeleteReservationResponse>(request);
    }
}
