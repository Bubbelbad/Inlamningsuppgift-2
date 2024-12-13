using Application.Commands.AuthorCommands.AddAuthor;
using Application.Commands.AuthorCommands.DeleteAuthor;
using Application.Commands.AuthorCommands.UpdateAuthor;
using Application.Dtos;
using Application.Dtos.AuthorDtos;
using Application.Queries.AuthorQueries;
using Application.Queries.AuthorQueries.GetAllAuthors;
using Application.Queries.AuthorQueries.GetAuthorById;
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
                var errors = new List<string>();
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
        [SwaggerOperation(Description = "Gets AuthorId by Id")]
        [SwaggerResponse(200, "Successfully retrieved AuthorId.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "AuthorId not found")]
        public async Task<IActionResult> GetAuthor([FromRoute] Guid id)
        {
            _logger.LogInformation("Fetching AuthorId with ID: {id} at {time}", id, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));

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
                    _logger.LogInformation("AuthorId with ID: {id} found", id);
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching AuthorId with ID: {id} at {time}", id, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return BadRequest(ex.InnerException);
            }
        }

        [Route("Create")]
        [HttpPost]
        [SwaggerOperation(Description = "Adds a new AuthorId to library")]
        [SwaggerResponse(200, "Successfully added AuthorId.")]
        [SwaggerResponse(400, "Invalid input data")]
        public async Task<IActionResult> AddAuthor([FromBody] AddAuthorDto authorToAdd)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid AuthorId data: {authorToAdd}", authorToAdd);
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation("Adding new AuthorId at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                var operationResult = await _mediator.Send(new AddAuthorCommand(authorToAdd));

                if (operationResult.IsSuccess)
                {
                    _logger.LogInformation("AuthorId added successfully");
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding new AuthorId at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Route("Update")]
        [HttpPut]
        [SwaggerOperation(Description = "Updates an existing AuthorId in the collection")]
        [SwaggerResponse(200, "Successfully Updated AuthorId.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "AuthorId not found")]
        public async Task<IActionResult> UpdateAuthor([FromBody, Required] UpdateAuthorDto authorToUpdate)
        {
            _logger.LogInformation("Updating AuthorId at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid AuthorId data: {ModelState}", ModelState);
                return BadRequest(ModelState);
            }

            try
            {
                var operationResult = await _mediator.Send(new UpdateAuthorCommand(authorToUpdate));
                if (operationResult.IsSuccess)
                {
                    _logger.LogInformation("AuthorId updated successfully");
                    return Ok(operationResult.Data);
                }

                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating AuthorId at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        [SwaggerOperation(Description = "Deletes AuthorId from collection")]
        [SwaggerResponse(200, "Successfully Deleted AuthorId.")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "AuthorId not found")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] Guid id)
        {
            _logger.LogInformation("Deleting AuthorId with ID: {id} at {time}", id, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid AuthorId ID: {id}", id);
                return BadRequest(ModelState);
            }

            try
            {
                var operationResult = await _mediator.Send(new DeleteAuthorCommand(id));
                if (operationResult.IsSuccess)
                {
                    _logger.LogInformation("AuthorId with ID: {id} deleted successfully", id);
                    return Ok(operationResult.Message);
                }
                _logger.LogWarning("AuthorId with ID: {id} not found. Error message: {operationResult.ErrorMessage}", id, operationResult.ErrorMessage);
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting AuthorId with ID: {id} at {time}", id, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
