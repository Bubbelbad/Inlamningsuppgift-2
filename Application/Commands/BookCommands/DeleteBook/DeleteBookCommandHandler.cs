using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using MediatR;


namespace Application.Commands.BookCommands.DeleteBook
{
    public class DeleteBookCommandHandler(IBookRepository bookRepository, IMapper mapper) : IRequestHandler<DeleteBookCommand, OperationResult<bool>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public IMapper _mapper = mapper;

        public async Task<OperationResult<bool>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool successfulDeletion = await _bookRepository.DeleteBook(request.BookIdToDelete);
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
