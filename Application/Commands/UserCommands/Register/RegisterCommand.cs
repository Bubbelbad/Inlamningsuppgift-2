using Application.Dtos;
using Application.Dtos.UserDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.UserCommands.Register
{
    public class RegisterCommand(UserDto newUser) : IRequest<OperationResult<GetUserDto>>
    {
        public UserDto NewUser { get; set; } = newUser;
    }
}
