using Application.Queries.AuthorQueries;
using Domain.Model;
using Infrastructure.Database;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator; 

        [Route("GetAuthorById/{id}")]
        [HttpGet]
        [SwaggerOperation(Description = "Gets a author by Id weather forecast")]
        [SwaggerResponse(200, "Successfully retrieved author.")]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            return Ok(await _mediator.Send(new GetAuthorByIdQuery(id)));
        }

        [Route("Add")]
        [HttpPost]
        [SwaggerOperation(Description = "Adds a new Author to library")]
        [SwaggerResponse(200, "Successfully added Author.")]
        public async Task<Author> Addauthor([FromBody] Author author)
        {
            throw new NotImplementedException();
            //return Ok(await _mediator.Send(new AddAuthor))
            //return authorService.AddNewAuthor(author);

        }

        [Route("Update")]
        [HttpPut]
        [SwaggerOperation(Description = "Updates an existing Author to library")]
        [SwaggerResponse(200, "Successfully Updated Author.")]
        public Task<Author> UpdateBook([FromBody] Author author)
        {
            throw new NotImplementedException();
            //return authorService.UpdateAuthor(author);
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        [SwaggerOperation(Description = "Deletes Author from library")]
        [SwaggerResponse(204, "Successfully Deleted Author.")]
        public Task<Author> DeleteAuthor(Guid id)
        {
            throw new NotImplementedException();
            //return authorService.DeleteAuthor(id);
        }
    }
}
