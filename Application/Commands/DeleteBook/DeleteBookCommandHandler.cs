using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using MediatR;


namespace Application.Commands.DeleteBook
{
    public class DeleteBookCommandHandler(IBookRepository bookRepository, IMapper mapper) : IRequestHandler<DeleteBookCommand, OperationResult<bool>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public IMapper _mapper = mapper;

        public async Task<OperationResult<bool>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            if (request.bookIdToDelete.Equals(Guid.Empty))
            {
                throw new ArgumentNullException(nameof(request), "Guid cannot be empty.");
            }

            try
            {
                bool successfulDeletion = await _bookRepository.DeleteBook(request.bookIdToDelete);
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
