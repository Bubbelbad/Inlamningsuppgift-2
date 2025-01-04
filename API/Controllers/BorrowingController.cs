using Application.Commands.BorrowingCommands.BorrowBookCopy;
using Application.Dtos.BorrowingDtos;
using Application.Queries.BorrowingQueries.GetBorrowingById;
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


        [HttpGet("GetById{id}")]
        [SwaggerOperation(Description = "Gets all borrowings from collection")]
        [SwaggerResponse(200, "Successfully retrieved Borrowings")]
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

        [HttpPost]
        [Route("BorrowBook")]
        [SwaggerOperation(Description = "User borrows a book from the database")]
        [SwaggerResponse(201, "Borrowing successfully created")]
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
                return BadRequest(operationResult);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpDelete]
        //public async Task<IActionResult> ReturnBook([FromBody] ReturnBookCommand command)
        //{
        //    var operationResult = await _mediator.Send(command);
        //    if (operationResult.Success)
        //    {
        //        return Ok(operationResult);
        //    }
        //    return BadRequest(operationResult);
        //}
    }
}
