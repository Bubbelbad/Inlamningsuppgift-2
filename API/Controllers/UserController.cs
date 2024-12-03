using Application.Commands.UserCommands.AddUser;
using Application.Dtos;
using Application.Queries.UserQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllUsers")]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _mediator.Send(new GetAllUsersQuery());
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody, Required] UserDto newUser)
        {
            if (newUser == null)
            {
                return BadRequest("Invalid input data.");
            }

            try
            {
                var addedUser = await _mediator.Send(new AddNewUserCommand(newUser));
                return Ok(addedUser);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody, Required] UserDto userWantingToLogIn)
        {
            if (userWantingToLogIn == null)
            {
                return BadRequest("Invalid input data.");
            }

            try
            {
                var loggedInUser = await _mediator.Send(new LoginUserQuery(userWantingToLogIn));
                return Ok(loggedInUser);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
