using Application.Dtos;
using Domain.Model;
using MediatR;


namespace Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommand(UpdateUserDto userToUpdate) : IRequest<OperationResult<User>>
    {
        public UpdateUserDto UserToUpdate { get; set; } = userToUpdate;
    }
}
