using Application.Models;
using MediatR;

namespace Application.Commands.UserCommands.DeleteUser
{
    public class DeleteUserCommand(Guid userId) : IRequest<OperationResult<bool>>
    {
        public Guid Id { get; set; } = userId;
    }
}
