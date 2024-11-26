using Application.Dtos;
using Domain.Model;
using MediatR;

namespace Application.Commands.UserCommands.AddUser
{
    public class AddNewUserCommand(UserDto newUser) : IRequest<User>
    {
        public UserDto NewUser { get; set; } = newUser; 
    }
}
