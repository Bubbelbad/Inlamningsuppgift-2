
using Application.Dtos.LibraryBranchDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Locations;
using MediatR;

namespace Application.Commands.LibraryBranchCommands.AddLibraryBranch
{
    public class AddLibraryBranchCommandHandler(IGenericRepository<LibraryBranch, int> repository, IMapper mapper) : IRequestHandler<AddLibraryBranchCommand, OperationResult<GetLibraryBranchDto>>
    {
        private readonly IGenericRepository<LibraryBranch, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetLibraryBranchDto>> Handle(AddLibraryBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                LibraryBranch libraryBranch = new()
                {
                    Name = request.dto.Name,
                    Location = request.dto.Location,
                    ContactInfo = request.dto.ContactInfo
                };

                var createdLibraryBranch = await _repository.AddAsync(libraryBranch);
                var mappedLibrary = _mapper.Map<GetLibraryBranchDto>(createdLibraryBranch);
                return OperationResult<GetLibraryBranchDto>.Success(mappedLibrary);
            }
            catch (Exception ex)
            {
                throw new Exception("Library branch not added", ex);
            }
        }
    }
}
