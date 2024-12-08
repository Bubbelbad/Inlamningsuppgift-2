using Application.Commands.UserCommands.AddUser;
using Application.Commands.UserCommands.DeleteUser;
using Application.Commands.UserCommands.UpdateUser;
using Application.Dtos;
using Application.Queries.UserQueries;
using Application.Queries.UserQueries.GetUserById;
using Application.Queries.UserQueries.GetUserByUsername;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator, ILogger<UserController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<UserController> _logger = logger;


        [HttpGet]
        [Route("GetAllUsers")]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        public async Task<IActionResult> GetAllUsers()
        {
            _logger.LogInformation("Fetching all Users at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
            try
            {
                var operationResult = await _mediator.Send(new GetAllUsersQuery());
                _logger.LogInformation("Successfully retrieved all Users");
                return Ok(operationResult.Data);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all Users at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("GetUserById")]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogWarning("Invalid input data");
                return BadRequest("Invalid input data.");
            }

            _logger.LogInformation("Fetching Users at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
            try
            {
                var operationResult = await _mediator.Send(new GetUserByIdQuery(id));
                _logger.LogInformation("Successfully retrieved all Users");
                return Ok(operationResult.Data);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all Users at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("GetUserByUsername")]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            if (username == string.Empty)
            {
                _logger.LogWarning("Invalid username, field cannot be empty");
                return BadRequest("Invalid input data.");
            }

            _logger.LogInformation("Fetching User at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
            try
            {
                var operationResult = await _mediator.Send(new GetUserByUsernameQuery(username));
                _logger.LogInformation("Successfully retrieved User");
                return Ok(operationResult.Data);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all Users at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody, Required] UserDto userWantingToLogIn)
        {
            _logger.LogInformation("Logging in User {username}", userWantingToLogIn.UserName);
            if (userWantingToLogIn == null)
            {
                _logger.LogWarning("Invalid input data");
                return BadRequest("Invalid input data.");
            }

            try
            {
                var loggedInUser = await _mediator.Send(new LoginUserQuery(userWantingToLogIn));
                _logger.LogInformation("User {username} logged in successfully", loggedInUser);
                return Ok(loggedInUser);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while logging in User");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody, Required] UserDto newUser)
        {
            _logger.LogInformation("Adding new User {username}", newUser.UserName);
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid input data");
                return BadRequest(ModelState);
            }

            try
            {
                var operationResult = await _mediator.Send(new AddNewUserCommand(newUser));
                _logger.LogInformation("User {username} added successfully", operationResult.Data.UserName);
                return Ok(operationResult.Data);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding new User");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }



        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody, Required] UpdateUserDto newUser)
        {
            _logger.LogInformation("Updating new User {username}", newUser.Username);
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid input data");
                return BadRequest(ModelState);
            }

            try
            {
                var operationResult = await _mediator.Send(new UpdateUserCommand(newUser));
                _logger.LogInformation("User {username} updated successfully", operationResult.Data.UserName);
                return Ok(operationResult.Data);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding new User");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete]
        [Route("DeleteUser{id}")]
        public async Task<IActionResult> DeleteUser([Required] Guid id)
        {
            _logger.LogInformation("Deleting user with ID: {id}", id);
            if (id == Guid.Empty)
            {
                _logger.LogWarning("Invalid input data");
                return BadRequest("Guid can not be empty");
            }

            try
            {
                var operationResult = await _mediator.Send(new DeleteUserCommand(id));
                _logger.LogInformation("User deleted successfully");
                return Ok(operationResult.Data);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding new User");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
