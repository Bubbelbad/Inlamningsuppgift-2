using Application.Dtos.UserDtos;
using MediatR;

namespace Application.Commands.UserCommands.LoginUser
{
    public class LoginUserCommand(LoginUserDto userDto) : IRequest<string>
    {
        public LoginUserDto UserDto { get; set; } = userDto;
    }
}
