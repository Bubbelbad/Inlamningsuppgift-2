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
    public class AuthorController(IMediator mediator, ILogger<AuthorController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<AuthorController> _logger = logger;

        // [Authorize]
        [Route("GetAllAuthors")]
        [HttpGet]
        [SwaggerOperation(Description = "Gets All Authors")]
        [SwaggerResponse(200, "Successfully retrieved Authors.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Authors not found")]
        public async Task<IActionResult> GetAllAuthors()
        {
            _logger.LogInformation("Fetching all Authors at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));

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

                _logger.LogWarning(errorMessages); 
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
                _logger.LogError(ex, "An error occurred while fetching all Authors at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
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
            _logger.LogInformation("Fetching Author with ID: {id} at {time}", id, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid ID: {Id}", id);
                return BadRequest(ModelState);
            }

            try
            {
                var operationResult = await _mediator.Send(new GetAuthorByIdQuery(id));

                if (operationResult.IsSuccess)
                {
                    _logger.LogInformation("Author with ID: {id} found", id);
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching Author with ID: {id} at {time}", id, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
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
                _logger.LogWarning("Invalid Author data: {authorToAdd}", authorToAdd);
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation("Adding new Author at {time}", authorToAdd, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                var operationResult = await _mediator.Send(new AddAuthorCommand(authorToAdd));

                if (operationResult.IsSuccess)
                { 
                    _logger.LogInformation("Author added successfully");
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding new Author at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
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
            _logger.LogInformation("Updating Author at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid Author data: {ModelState}", ModelState);
                return BadRequest(ModelState);
            }

            try
            {
                var operationResult = await _mediator.Send(new UpdateAuthorCommand(authorToUpdate));
                if (operationResult.IsSuccess)
                {
                    _logger.LogInformation("Author updated successfully");
                    return Ok(operationResult.Data);
                }

                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating Author at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
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
            _logger.LogInformation("Deleting Author with ID: {id} at {time}", id, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid Author ID: {id}", id);
                return BadRequest(ModelState);
            }

            try
            {
                var operationResult = await _mediator.Send(new DeleteAuthorCommand(id));
                if (operationResult.IsSuccess)
                {
                    _logger.LogInformation("Author with ID: {id} deleted successfully", id);
                    return Ok(operationResult.Message);
                }
                _logger.LogWarning("Author with ID: {id} not found. Error message: {operationResult.ErrorMessage}", id, operationResult.ErrorMessage);
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting Author with ID: {id} at {time}", id, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
