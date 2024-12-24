using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Application.Queries.BookQueries.GetBookCopyById;
using Application.Dtos.BookCopyDtos;
using Application.Commands.BookCopyCommands.AddBookCopy;
using Application.Queries.BookCopyQueries.GetAllBookCopies;
using Application.Commands.BookCopyCommands.DeleteBookCopy;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCopyController(IMediator mediator, ILogger<BookController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<BookController> _logger = logger;

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllBookCopies()
        {
            var operationResult = await _mediator.Send(new GetAllBookCopiesQuery());
            if (operationResult.IsSuccess)
            {
                return Ok(operationResult.Data);
            }
            return BadRequest();
        }

        [Route("GetById/{bookId}")]
        [HttpGet]
        [SwaggerOperation(Description = "Gets a book by Id")]
        [SwaggerResponse(200, "Successfully retrieved Book.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Book not found")]
        public async Task<IActionResult> GetBookCopy([FromRoute] Guid bookId)
        {
            try
            {
                var operationResult = await _mediator.Send(new GetBookCopyByIdQuery(bookId));
                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching Book with ID: {id} at {time}", bookId, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBookCopy([FromBody] AddBookCopyDto dto)
        {
            try
            {
                var operationResult = await _mediator.Send(new AddBookCopyCommand(dto));
                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new BookCopy at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBookCopy()
        {
            try
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating BookCopy at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBookCopy(Guid id)
        {
            try
            {
                var operationResult = await _mediator.Send(new DeleteBookCopyCommand(id));
                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting BookCopy with ID: {id} at {time}", id, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
