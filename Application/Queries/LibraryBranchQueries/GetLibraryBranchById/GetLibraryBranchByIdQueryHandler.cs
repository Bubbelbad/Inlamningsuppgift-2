using Application.Dtos.LibraryBranchDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Locations;
using MediatR;

namespace Application.Queries.LibraryBranchQueries.GetLibraryBranchById
{
    internal class GetLibraryBranchByIdQueryHandler(IGenericRepository<LibraryBranch, int> repository, IMapper mapper) : IRequestHandler<GetLibraryBranchByIdQuery, OperationResult<GetLibraryBranchDto>>
    {
        private readonly IGenericRepository<LibraryBranch, int> _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<OperationResult<GetLibraryBranchDto>> Handle(GetLibraryBranchByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var libraryBranch = await _repository.GetByIdAsync(request.Id);
                var mappedLibraryBranch = _mapper.Map<GetLibraryBranchDto>(libraryBranch);
                return OperationResult<GetLibraryBranchDto>.Success(mappedLibraryBranch);
            }
            catch (Exception ex)
            {
                throw new Exception("Nope", ex);
            }
        }
    }
}
