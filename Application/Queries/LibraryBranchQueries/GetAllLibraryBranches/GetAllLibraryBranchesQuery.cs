using Application.Dtos.LibraryBranchDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.LibraryBranchQueries.GetAllLibraryBranches
{
    public class GetAllLibraryBranchesQuery() : IRequest<OperationResult<List<GetLibraryBranchDto>>>
    {

    }
}
