using Application.Commands.ReservationCommands.AddReservation;
using Application.Commands.ReservationCommands.DeleteReservation;
using Application.Dtos.ReservationDtos;
using Application.Queries.ReservationQueries.GetAllReservations;
using Application.Queries.ReservationQueries.GetReservationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Description = "Gets all reservations")]
        [SwaggerResponse(200, "Successfully retrieved Reservations.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Reservations not found")]
        public async Task<IActionResult> GetAllReservations()
        {
            var operationResult = await _mediator.Send(new GetAllReservationsQuery());
            if (operationResult.IsSuccess)
            {
                return Ok(operationResult.Data);
            }
            return BadRequest();
        }

        [Route("GetById/{id}")]
        [HttpGet]
        [SwaggerOperation(Description = "Gets a reservation by id")]
        [SwaggerResponse(200, "Successfully retrieved Reservation.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Reservation not found")]
        public async Task<IActionResult> GetReservation([FromRoute] int id)
        {
            try
            {
                var operationResult = await _mediator.Send(new GetReservationByIdQuery(id));
                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching Reservation with ID: {id} at {time}", id, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        [Route("Create")]
        [SwaggerOperation(Description = "Adds a new reservation")]
        [SwaggerResponse(201, "Successfully added Reservation.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Reservation not found")]
        public async Task<IActionResult> AddReservation([FromBody] AddReservationDto dto)
        {
            try
            {
                var operationResult = await _mediator.Send(new AddReservationCommand(dto));
                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }

            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while adding new Reservation at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete]
        [Route("Delete{id}")]
        [SwaggerOperation(Description = "Deletes a new reservation")]
        [SwaggerResponse(201, "Successfully deleted Reservation.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Reservation not found")]
        public async Task<IActionResult> DeleteReservation([FromBody] int id)
        {
            try
            {
                var operationResult = await _mediator.Send(new DeleteReservationCommand(id));
                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }

            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while deleting new Reservation at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
