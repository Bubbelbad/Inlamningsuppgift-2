using Application.Commands.AddAuthorCommands.AddAuthor;
using Application.Commands.AuthorCommands.DeleteAuthor;
using Application.Dtos;
using Application.Queries.AuthorQueries;
using Application.Queries.BookQueries;
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
        [SwaggerOperation(Description = "Gets Author by Id")]
        [SwaggerResponse(200, "Successfully retrieved Author.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Author not found")]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            if (id == null)
            {
                return BadRequest(400);
            }

            var foundAuthor = await _mediator.Send(new GetAuthorByIdQuery(id));

            if (foundAuthor == null)
            {
                return NotFound("Book not found");
            }

            return Ok(foundAuthor);
        }

        [Route("Create")]
        [HttpPost]
        [SwaggerOperation(Description = "Adds a new Author to library")]
        [SwaggerResponse(200, "Successfully added Author.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Author not found")]
        public async Task<IActionResult> AddAuthor([FromBody] AddAuthorDto authorToAdd)
        {
            if (authorToAdd == null)
            {
                return BadRequest("Invalid input data.");
            }

            var addedAuthor = await _mediator.Send(new AddAuthorCommand(authorToAdd));

            if (addedAuthor == null)
            {
                return NotFound("Author not found.");
            }

            return Ok(addedAuthor);

        }

        [Route("Update")]
        [HttpPut]
        [SwaggerOperation(Description = "Updates an existing Author to library")]
        [SwaggerResponse(200, "Successfully Updated Author.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Author not found")]
        public async Task<IActionResult> UpdateAuthor([FromBody] Guid authorId)
        {
            if (authorId == null)
            {
                return BadRequest("Invalid input data.");
            }

            var updatedBook = await _mediator.Send(new DeleteAuthorCommand(authorId));

            if (updatedBook == null)
            {
                return NotFound("Author not found.");
            }

            return Ok(updatedBook);
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        [SwaggerOperation(Description = "Deletes Author from library")]
        [SwaggerResponse(204, "Successfully Deleted Author.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Author not found")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var deletedBook = await _mediator.Send(new DeleteAuthorCommand(id));

            if (deletedBook == null)
            {
                return NotFound("Author not found.");
            }
            return NoContent();
        }
    }
}
