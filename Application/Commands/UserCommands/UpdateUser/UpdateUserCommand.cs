using Application.Dtos;
using Application.Models;
using Domain.Entities.Core;
using MediatR;


namespace Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommand(UpdateUserDto userToUpdate) : IRequest<OperationResult<User>>
    {
        public UpdateUserDto UserToUpdate { get; set; } = userToUpdate;
    }
}
