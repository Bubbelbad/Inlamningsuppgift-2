using Application.Commands.AddBook;
using Application.Commands.DeleteBook;
using Application.Commands.UpdateBook;
using Application.Dtos;
using Application.Queries.BookQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BookController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator; 

        [Route("GetBookById/{bookId}")]
        [HttpGet]
        [SwaggerOperation(Description = "Gets a book by Id")]
        [SwaggerResponse(200, "Successfully retrieved Book.")]
        public async Task<IActionResult> GetBook(Guid bookId)
        {
            return Ok(await _mediator.Send(new GetBookByIdQuery(bookId)));
        }

        [Route("AddNewBook")]
        [HttpPost]
        [SwaggerOperation(Description = "Adds a new Book to library")]
        [SwaggerResponse(200, "Successfully added Book.")]
        public async Task<IActionResult> AddBook([FromBody]BookDto bookToAdd)
        {
            return Ok(await _mediator.Send(new AddBookCommand(bookToAdd)));
        }

        [Route("Update")]
        [HttpPut]
        [SwaggerOperation(Description = "Updates an existing Book to library")]
        [SwaggerResponse(200, "Successfully Updated Book.")]
        public async Task<IActionResult> UpdateBook([FromBody]BookDto book)
        {
            return Ok(await _mediator.Send(new UpdateBookCommand(book)));
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        [SwaggerOperation(Description = "Deletes Book from library")]
        [SwaggerResponse(204, "Successfully Deleted Book.")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {

            return Ok(await _mediator.Send(new DeleteBookCommand(id)));
        }
    }
}
