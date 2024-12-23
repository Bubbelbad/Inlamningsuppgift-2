
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Locations;
using MediatR;

namespace Application.Commands.LibraryBranchCommands.DeleteLibraryBranch
{
    internal class DeleteLibraryBranchCommandHandler(IGenericRepository<LibraryBranch, int> repository, IMapper mapper) : IRequestHandler<DeleteLibraryBranchCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<LibraryBranch, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<bool>> Handle(DeleteLibraryBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var successfulDeletion = await _repository.DeleteAsync(request.Id);
                if (successfulDeletion)
                {
                    return OperationResult<bool>.Success(successfulDeletion);
                }
                return OperationResult<bool>.Failure("Library branch not deleted");
            }
            catch (Exception ex)
            {
                throw new Exception("Nope", ex);
            }
        }
    }
}
