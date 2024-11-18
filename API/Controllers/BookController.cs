using Application;
using Domain;
using Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BookController : ControllerBase
    {
        [Route("Get/{id}")]
        [HttpGet]
        [SwaggerOperation(Description = "Gets a book by Id weather forecast")]
        [SwaggerResponse(200, "Successfully retrieved Book.")]
        public Task<Book> GetBook(Guid id)
        {
            FakeDatabase fakeDatabase = new(); 
            BookService bookService = new(fakeDatabase);
            return bookService.GetBookById(id);
        }

        [Route("Add")]
        [HttpPost]
        [SwaggerOperation(Description = "Adds a new Book to library")]
        [SwaggerResponse(200, "Successfully added Book.")]
        public Task<Book> AddBook([FromBody]Book book)
        {
            FakeDatabase fakeDatabase = new();
            BookService bookService = new(fakeDatabase);
            return bookService.AddBook(book);
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

        [Route("Delete/{id}")]
        [HttpPost]
        [SwaggerOperation(Description = "Deletes Book from library")]
        [SwaggerResponse(204, "Successfully Deleted Book.")]
        public Task<Book> DeleteBook(Guid id)
        {
            FakeDatabase fakeDatabase = new();
            BookService bookService = new(fakeDatabase);
            return bookService.DeleteBook(id);
        }
    }
}
