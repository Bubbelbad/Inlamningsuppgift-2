using Application.Dtos;
using Application.Models;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.UserCommands.Register
{
    public class RegisterCommand(UserDto newUser) : IRequest<OperationResult<User>>
    {
        public UserDto NewUser { get; set; } = newUser;
    }
}
