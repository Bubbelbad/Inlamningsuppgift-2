using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserCommands.DeleteUser
{
    public class DeleteUserCommand(Guid userId) : IRequest<OperationResult<bool>>
    {
        public Guid Id { get; set; } = userId;
    }
}
