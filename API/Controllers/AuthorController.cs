using Application;
using Application.Services;
using Domain;
using Domain.Model;
using Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    public class AuthorController
    {
        [Route("Get/{id}")]
        [HttpGet]
        [SwaggerOperation(Description = "Gets a author by Id weather forecast")]
        [SwaggerResponse(200, "Successfully retrieved author.")]
        public Task<Author> GetAuthor(Guid id)
        {
            FakeDatabase fakeDatabase = new();
            AuthorService authorService = new(fakeDatabase);
            return authorService.GetAuthorById(id);
        }

        [Route("Add")]
        [HttpPost]
        [SwaggerOperation(Description = "Adds a new Author to library")]
        [SwaggerResponse(200, "Successfully added Author.")]
        public Task<Author> Addauthor([FromBody] Author author)
        {
            FakeDatabase fakeDatabase = new();
            AuthorService authorService = new(fakeDatabase);
            return authorService.AddNewAuthor(author);
        }

        [Route("Update")]
        [HttpPost]
        [SwaggerOperation(Description = "Updates an existing Author to library")]
        [SwaggerResponse(200, "Successfully Updated Author.")]
        public Task<Author> UpdateBook([FromBody] Author author)
        {
            FakeDatabase fakeDatabase = new();
            AuthorService authorService = new(fakeDatabase);
            return authorService.UpdateAuthor(author);
        }

        [Route("Delete/{id}")]
        [HttpPost]
        [SwaggerOperation(Description = "Deletes Author from library")]
        [SwaggerResponse(204, "Successfully Deleted Author.")]
        public Task<Author> DeleteAuthor(Guid id)
        {
            FakeDatabase fakeDatabase = new();
            AuthorService authorService = new(fakeDatabase);
            return authorService.DeleteAuthor(id);
        }
    }
}
