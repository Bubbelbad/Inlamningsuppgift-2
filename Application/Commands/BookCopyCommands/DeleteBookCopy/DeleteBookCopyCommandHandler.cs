using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Locations;
using MediatR;

namespace Application.Commands.BookCopyCommands.DeleteBookCopy
{
    internal class DeleteBookCopyCommandHandler(IGenericRepository<BookCopy, Guid> repository, IMapper mapper) : IRequestHandler<DeleteBookCopyCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<BookCopy, Guid> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<bool>> Handle(DeleteBookCopyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var successfulDeletion = await _repository.DeleteAsync(request.Id);
                if (successfulDeletion)
                {
                    return OperationResult<bool>.Success(successfulDeletion);
                }
                return OperationResult<bool>.Failure("Operation failed");
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred.", ex);
            }
        }
    }
}
