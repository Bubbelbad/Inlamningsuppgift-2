using Application.Commands.BorrowingCommands.BorrowBookCopy;
using Application.Commands.BorrowingCommands.ReturnBookCopy;
using Application.Dtos.BorrowingDtos;
using Application.Queries.BorrowingQueries.GetAllBorrowings;
using Application.Queries.BorrowingQueries.GetBorrowingById;
using Application.Queries.BorrowingQueries.GetUserBorrowings;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq.Expressions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;


        [HttpGet]
        [Route("GetAll")]
        [SwaggerOperation(Description = "Gets all borrowings from collection")]
        [SwaggerResponse(200, "Successfully retrieved all borrowings")]
        [SwaggerResponse(404, "Borrowings not found.")]
        public async Task<IActionResult> GetAllBorrowings()
        {
            try
            {
                var operationResult = await _mediator.Send(new GetAllBorrowingsQuery());
                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetById{id}")]
        [SwaggerOperation(Description = "Gets borrowing by Id from collection")]
        [SwaggerResponse(200, "Successfully retrieved Borrowing")]
        [SwaggerResponse(404, "Borrowing not found.")]
        public async Task<IActionResult> GetBorrowingById(int id)
        {
            try
            {
                var operationResult = await _mediator.Send(new GetBorrowingByIdQuery(id));
                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetUserBorrowings{id}")]
        [SwaggerOperation(Description = "Gets user borrowing by userId from collection")]
        [SwaggerResponse(200, "Successfully retrieved users Borrowings")]
        [SwaggerResponse(404, "Borrowings not found.")]
        public async Task<IActionResult> GetBorrowingById(Guid id)
        {
            try
            {
                var operationResult = await _mediator.Send(new GetUserBorrowingsQuery(id));
                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("BorrowBook")]
        [SwaggerOperation(Description = "User borrows a book from the database")]
        [SwaggerResponse(201, "Book copy successfully borrowed")]
        [SwaggerResponse(400, "Invalid input data")]
        public async Task<IActionResult> AddBorrowing([FromBody] BorrowBookDto dto)
        {
            try
            {
                var operationResult = await _mediator.Send(new BorrowBookCopyCommand(dto));
                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("ReturnBookCopy{borrowingId}")]
        [SwaggerOperation(Description = "Returns book")]
        [SwaggerResponse(201, "BookCopy successfully returned")]
        [SwaggerResponse(400, "Invalid input data")]
        public async Task<IActionResult> ReturnBook(int borrowingId)
        {
            try
            {
                var operationResult = await _mediator.Send(new ReturnBookCopyCommand(borrowingId));
                if (operationResult.IsSuccess)
                {
                    return StatusCode(201, operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
