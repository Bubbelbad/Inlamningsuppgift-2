using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using MediatR;

namespace Application.Commands.UpdateBook
{
    public class UpdateBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.NewBook == null || string.IsNullOrEmpty(request.NewBook.Title))
            {
                return Task.FromResult<Book>(null);
            }

            try
            {
                Book bookToUpdate = new Book(request.NewBook.Id, request.NewBook.Title, request.NewBook.Author, request.NewBook.Description); 
                return _bookRepository.UpdateBook(bookToUpdate);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred.", ex);
            }
        }
    }
}
