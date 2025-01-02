using Application.Queries.ReservationQueries.GetAllReservations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController(IMediator mediator, ILogger<ReservationController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<ReservationController> _logger = logger;


        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllReservations()
        {
            var operationResult = await _mediator.Send(new GetAllReservationsQuery());
            if (operationResult.IsSuccess)
            {
                return Ok(operationResult.Data);
            }
            return BadRequest();
        }

        //[Route("GetById/{reservationId}")]
        //[HttpGet]
        //[SwaggerOperation(Description = "Gets a reservation by Id")]
        //[SwaggerResponse(200, "Successfully retrieved Reservation.")]
        //[SwaggerResponse(400, "Invalid input data")]
        //[SwaggerResponse(404, "Reservation not found")]
        //public async Task<IActionResult> GetReservation([FromRoute] Guid reservationId)
        //{
        //    try
        //    {
        //        var operationResult = await _mediator.Send(new GetReservationByIdQuery(reservationId));
        //        if (operationResult.IsSuccess)
        //        {
        //            return Ok(operationResult.Data);
        //        }
        //        return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
        //    }

        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An error occurred while fetching Reservation with ID: {id} at {time}", reservationId, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
        //        return StatusCode(500, "An error occurred while processing your request.");
        //    }
        //}

        //[HttpPost]
        //[Route("Add")]
        //[SwaggerOperation(Description = "Adds a new reservation")]
        //[SwaggerResponse(201, "Successfully added Reservation.")]
        //[SwaggerResponse(400, "Invalid input data")]
        //[SwaggerResponse(404, "Reservation not found")]
        //public async Task<IActionResult> AddReservation([FromBody] AddReservationCommand command)
        //{
        //    try
        //    {
        //        var operationResult = await _mediator.Send(command);
        //        if (operationResult.IsSuccess)
        //        {
        //            return CreatedAtAction(nameof(GetReservation), new { reservationId = operationResult.Data }, operationResult.Data);
        //        }
        //        return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
        //    }

        //    catch (Exception e)
        //    {
        //        _logger.LogError(e, "An error occurred while adding new Reservation at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
        //        return StatusCode(500, "An error occurred while processing your request.");
        //    }
        //}
    }
}
