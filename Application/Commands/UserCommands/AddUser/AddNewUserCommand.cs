using Application.Dtos;
using Domain.Model;
using MediatR;

namespace Application.Commands.UserCommands.AddUser
{
    public class AddNewUserCommand(UserDto newUser) : IRequest<OperationResult<User>>
    {
        public UserDto NewUser { get; set; } = newUser;
    }
}
