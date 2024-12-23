using Application.Dtos.LibraryBranchDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.LibraryBranchQueries.GetLibraryBranchById
{
    public class GetLibraryBranchByIdQuery(int id) : IRequest<OperationResult<GetLibraryBranchDto>>
    {
        public int Id { get; set; } = id;
    }
}
