using Application.Dtos.LibraryBranchDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.LibraryBranchCommands.UpdateLibraryBranch
{
    public class UpdateLibraryBranchCommand(UpdateLibraryBranchDto dto) : IRequest<OperationResult<GetLibraryBranchDto>>
    {
        public UpdateLibraryBranchDto dto { get; set; } = dto;
    }
}
