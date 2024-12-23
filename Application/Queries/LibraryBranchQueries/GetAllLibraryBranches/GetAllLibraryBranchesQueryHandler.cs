using Application.Dtos.LibraryBranchDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Locations;
using MediatR;

namespace Application.Queries.LibraryBranchQueries.GetAllLibraryBranches
{
    internal class GetAllLibraryBranchesQueryHandler(IGenericRepository<LibraryBranch, int> repository, IMapper mapper) : IRequestHandler<GetAllLibraryBranchesQuery, OperationResult<List<GetLibraryBranchDto>>>
    {
        private readonly IGenericRepository<LibraryBranch, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<List<GetLibraryBranchDto>>> Handle(GetAllLibraryBranchesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allLibraryBranches = await _repository.GetAllAsync();
                var mappedLibraryBranches = _mapper.Map<List<GetLibraryBranchDto>>(allLibraryBranches);
                return OperationResult<List<GetLibraryBranchDto>>.Success(mappedLibraryBranches);
            }
            catch (Exception ex)
            {
                throw new Exception("Nope", ex);
            }
        }
    }
}
