using Application.Models;
using MediatR;

namespace Application.Commands.LibraryBranchCommands.DeleteLibraryBranch
{
    public class DeleteLibraryBranchCommand(int id) : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; } = id;
    }
}
