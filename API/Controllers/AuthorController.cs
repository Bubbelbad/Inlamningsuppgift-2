using Application.Commands.AddAuthorCommands.AddAuthor;
using Application.Commands.AuthorCommands.DeleteAuthor;
using Application.Dtos;
using Application.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Application.Commands.AuthorCommands.UpdateAuthor;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [Route("GetAuthorById/{id}")]
        [HttpGet]
        [SwaggerOperation(Description = "Gets Author by Id")]
        [SwaggerResponse(200, "Successfully retrieved Author.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Author not found")]
        public async Task<IActionResult> GetAuthor([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid author ID.");
            }

            try
            {
                var foundAuthor = await _mediator.Send(new GetAuthorByIdQuery(id));
                if (foundAuthor == null)
                {
                    return NotFound("Author not found.");
                }

                return Ok(foundAuthor);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Route("Create")]
        [HttpPost]
        [SwaggerOperation(Description = "Adds a new Author to library")]
        [SwaggerResponse(200, "Successfully added Author.")]
        [SwaggerResponse(400, "Invalid input data")]
        public async Task<IActionResult> AddAuthor([FromBody, Required] AddAuthorDto authorToAdd)
        {
            if (authorToAdd == null)
            {
                return BadRequest("Invalid input data.");
            }

            try
            {
                var addedAuthor = await _mediator.Send(new AddAuthorCommand(authorToAdd));
                return Ok(addedAuthor);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Route("Update")]
        [HttpPut]
        [SwaggerOperation(Description = "Updates an existing Author in the collection")]
        [SwaggerResponse(200, "Successfully Updated Author.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Author not found")]
        public async Task<IActionResult> UpdateAuthor([FromBody, Required] AuthorDto authorToUpdate)
        {
            if (authorToUpdate == null)
            {
                return BadRequest("Invalid input data.");
            }

            try
            {
                var updatedAuthor = await _mediator.Send(new UpdateAuthorCommand(authorToUpdate));
                if (updatedAuthor == null)
                {
                    return NotFound("Author not found.");
                }

                return Ok(updatedAuthor);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        [SwaggerOperation(Description = "Deletes Author from collection")]
        [SwaggerResponse(204, "Successfully Deleted Author.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Author not found")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid author ID.");
            }

            try
            {
                var deletedAuthor = await _mediator.Send(new DeleteAuthorCommand(id));
                if (deletedAuthor == null)
                {
                    return NotFound("Author not found.");
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
