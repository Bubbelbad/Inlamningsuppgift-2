using Application.Commands.AddBook;
using Application.Commands.DeleteBook;
using Application.Commands.UpdateBook;
using Application.Queries.BookQueries;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("GetAllBooks")]
        [HttpGet]
        [SwaggerOperation(Description = "Gets all books")]
        [SwaggerResponse(200, "Successfully retrieved Books.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Books not found")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var foundBooks = await _mediator.Send(new GetAllBooksQuery());
                if (foundBooks == null)
                {
                    return NotFound("Book not found.");
                }

                return Ok(foundBooks);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Route("GetBookById/{bookId}")]
        [HttpGet]
        [SwaggerOperation(Description = "Gets a book by Id")]
        [SwaggerResponse(200, "Successfully retrieved Book.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Book not found")]
        public async Task<IActionResult> GetBook([FromRoute] Guid bookId)
        {
            if (bookId == Guid.Empty)
            {
                return BadRequest("Invalid book ID.");
            }

            try
            {
                var foundBook = await _mediator.Send(new GetBookByIdQuery(bookId));
                if (foundBook == null)
                {
                    return NotFound("Book not found.");
                }

                return Ok(foundBook);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Route("Create")]
        [HttpPost]
        [SwaggerOperation(Description = "Adds a new Book to library")]
        [SwaggerResponse(200, "Successfully added Book.")]
        [SwaggerResponse(400, "Invalid input data.")]
        public async Task<IActionResult> AddBook([FromBody, Required] AddBookDto bookToAdd)
        {
            if (bookToAdd == null)
            {
                return BadRequest("Invalid input data.");
            }

            try
            {
                var addedBook = await _mediator.Send(new AddBookCommand(bookToAdd));
                return Ok(addedBook);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Route("Update")]
        [HttpPut]
        [SwaggerOperation(Description = "Updates an existing Book in collection")]
        [SwaggerResponse(200, "Successfully Updated Book.", typeof(BookDto))]
        [SwaggerResponse(400, "Invalid input data.")]
        [SwaggerResponse(404, "Book not found.")]
        public async Task<IActionResult> UpdateBook([FromBody, Required] BookDto book)
        {
            if (book == null)
            {
                return BadRequest("Invalid input data.");
            }

            try
            {
                var updatedBook = await _mediator.Send(new UpdateBookCommand(book));
                if (updatedBook == null)
                {
                    return NotFound("Book not found.");
                }

                return Ok(updatedBook);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        [SwaggerOperation(Description = "Deletes a Book from collection")]
        [SwaggerResponse(204, "Successfully Deleted Book.")]
        [SwaggerResponse(404, "Book not found.")]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid book ID.");
            }

            try
            {
                var deletedBook = await _mediator.Send(new DeleteBookCommand(id));
                if (deletedBook == null)
                {
                    return NotFound("Book not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
