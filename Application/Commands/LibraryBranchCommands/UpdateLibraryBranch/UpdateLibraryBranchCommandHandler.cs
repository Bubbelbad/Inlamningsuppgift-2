
using Application.Dtos.LibraryBranchDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Locations;
using MediatR;

namespace Application.Commands.LibraryBranchCommands.UpdateLibraryBranch
{
    public class UpdateLibraryBranchCommandHandler(IGenericRepository<LibraryBranch, int> repository, IMapper mapper) : IRequestHandler<UpdateLibraryBranchCommand, OperationResult<GetLibraryBranchDto>>
    {
        private readonly IGenericRepository<LibraryBranch, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetLibraryBranchDto>> Handle(UpdateLibraryBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                LibraryBranch libraryBranch = new()
                {
                    BranchId = request.dto.Id,
                    Name = request.dto.Name,
                    Location = request.dto.Location,
                    ContactInfo = request.dto.ContactInfo
                };

                var updatedLibraryBranch = await _repository.UpdateAsync(libraryBranch);
                var mappedLibraryBranch = _mapper.Map<GetLibraryBranchDto>(updatedLibraryBranch);
                return OperationResult<GetLibraryBranchDto>.Success(mappedLibraryBranch);
            }
            catch (Exception ex)
            {
                throw new Exception("Nope", ex);
            }
        }
    }
}
