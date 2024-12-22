using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Application.Queries.BookQueries.GetBookCopyById;
using Application.Dtos.BookCopyDtos;
using Application.Commands.BookCopyCommands.AddBookCopy;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCopyController(IMediator mediator, ILogger<BookController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<BookController> _logger = logger;

        [HttpGet]
        [Route("GetAllBookCopies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllBookCopies()
        {
            return Ok();
        }

        [Route("GetBookCopyById/{bookId}")]
        [HttpGet]
        [SwaggerOperation(Description = "Gets a book by Id")]
        [SwaggerResponse(200, "Successfully retrieved Book.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Book not found")]
        public async Task<IActionResult> GetBook([FromRoute] Guid bookId)
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
        [Route("AddBookCopy")]
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
        [Route("UpdateBookCopy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBookCopy()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteBookCopy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBookCopy(Guid id)
        {
            return Ok();
        }
    }
}
