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
        public async Task<IActionResult> AddBook([FromBody]AddBookDto bookToAdd)
        {
            return Ok(await _mediator.Send(new AddBookCommand(bookToAdd)));
        }

        [Route("Update")]
        [HttpPut]
        [SwaggerOperation(Description = "Updates an existing Book in the library")]
        [SwaggerResponse(200, "Successfully Updated Book.", typeof(BookDto))]
        [SwaggerResponse(400, "Invalid input data.")]
        [SwaggerResponse(404, "Book not found.")]
        public async Task<IActionResult> UpdateBook([FromBody] BookDto book)
        {
            if (book == null)
            {
                return BadRequest("Invalid input data.");
            }

            var updatedBook = await _mediator.Send(new UpdateBookCommand(book));

            if (updatedBook == null)
            {
                return NotFound("Book not found.");
            }

            return Ok(updatedBook);
        }


        [Route("Delete/{id}")]
        [HttpDelete]
        [SwaggerOperation(Description = "Deletes a Book from the library")]
        [SwaggerResponse(204, "Successfully Deleted Book.")]
        [SwaggerResponse(404, "Book not found.")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var deletedBook = await _mediator.Send(new DeleteBookCommand(id));

            if (deletedBook == null)
            {
                return NotFound("Book not found.");
            }
            return NoContent();
        }

    }
}
