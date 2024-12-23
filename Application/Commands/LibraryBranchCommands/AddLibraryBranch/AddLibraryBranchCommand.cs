using Application.Dtos.LibraryBranchDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.LibraryBranchCommands.AddLibraryBranch
{
    public class AddLibraryBranchCommand(AddLibraryBranchDto dto) : IRequest<OperationResult<GetLibraryBranchDto>>
    {
        public AddLibraryBranchDto dto { get; set; } = dto;
    }
}
