using Application.Commands.AddAuthorCommands.AddAuthor;
using Application.Commands.AuthorCommands.DeleteAuthor;
using Application.Commands.AuthorCommands.UpdateAuthor;
using Application.Dtos;
using Application.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        // [Authorize]
        [Route("GetAllAuthors")]
        [HttpGet]
        [SwaggerOperation(Description = "Gets All Authors")]
        [SwaggerResponse(200, "Successfully retrieved Authors.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Authors not found")]
        public async Task<IActionResult> GetAllAuthors()
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = new List<string>(); 
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage); 
                    }
                }
                string errorMessages = string.Join("\n", errors); 
                return BadRequest(errorMessages);
            }

            try
            {
                var operationResult = await _mediator.Send(new GetAllAuthorsQuery());

                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }

            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        // [Authorize]
        [Route("GetAuthorById/{id}")]
        [HttpGet]
        [SwaggerOperation(Description = "Gets Author by Id")]
        [SwaggerResponse(200, "Successfully retrieved Author.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Author not found")]
        public async Task<IActionResult> GetAuthor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var operationResult = await _mediator.Send(new GetAuthorByIdQuery(id));

                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });

            }
            catch (Exception ex)
            { 
                return BadRequest(ex.InnerException);
            }
        }

        [Route("Create")]
        [HttpPost]
        [SwaggerOperation(Description = "Adds a new Author to library")]
        [SwaggerResponse(200, "Successfully added Author.")]
        [SwaggerResponse(400, "Invalid input data")]
        public async Task<IActionResult> AddAuthor([FromBody, Required] AddAuthorDto authorToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var operationResult = await _mediator.Send(new AddAuthorCommand(authorToAdd));

                if (operationResult.IsSuccess)
                { 
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var operationResult = await _mediator.Send(new UpdateAuthorCommand(authorToUpdate));
                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult.Data);
                }

                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
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
        [SwaggerResponse(200, "Successfully Deleted Author.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Author not found")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var operaionResult = await _mediator.Send(new DeleteAuthorCommand(id));
                if (operaionResult.IsSuccess)
                {
                    return Ok(operaionResult.Message);
                }
                return BadRequest(new { message = operaionResult.Message, errors = operaionResult.ErrorMessage });
            }

            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
