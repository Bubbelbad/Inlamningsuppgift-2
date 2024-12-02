using Application.Interfaces.RepositoryInterfaces;
using MediatR;


namespace Application.Commands.DeleteBook
{
    public class DeleteBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }

            try
            {
                var boolean = _bookRepository.DeleteBook(request.bookIdToDelete);
                return boolean; 
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred.", ex);
            }
        }
    }
}
