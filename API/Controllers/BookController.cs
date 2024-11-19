using Application;
using Application.Commands.AddBook;
using Application.Dtos;
using Application.Queries.BookQueries;
using Domain.Model;
using Infrastructure.Database;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator; 

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
        [HttpPost]
        [SwaggerOperation(Description = "Updates an existing Book to library")]
        [SwaggerResponse(200, "Successfully Updated Book.")]
        public Task<Book> UpdateBook([FromBody]Book book)
        {
            FakeDatabase fakeDatabase = new();
            BookService bookService = new(fakeDatabase);
            return bookService.UpdateBook(book);
        }

        //[Route("Delete/{id}")]
        //[HttpPost]
        //[SwaggerOperation(Description = "Deletes Book from library")]
        //[SwaggerResponse(204, "Successfully Deleted Book.")]
        //public Task<Book> DeleteBook(Guid id)
        //{
        //    FakeDatabase fakeDatabase = new();
        //    BookService bookService = new(fakeDatabase);
        //    return bookService.DeleteBook(id);
        //}
    }
}
