using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;


namespace Application.Commands.BookCommands.DeleteBook
{
    public class DeleteBookCommandHandler(IGenericRepository<Book, Guid> repository, IMapper mapper) : IRequestHandler<DeleteBookCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<Book, Guid> _repository = repository;
        public IMapper _mapper = mapper;

        public async Task<OperationResult<bool>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool successfulDeletion = await _repository.DeleteAsync(request.BookIdToDelete);
                var mappedBool = _mapper.Map<bool>(successfulDeletion);
                if (successfulDeletion)
                {
                    return OperationResult<bool>.Success(mappedBool);
                }

                return OperationResult<bool>.Failure("Operation failed");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred.", ex);
            }
        }
    }
}
