using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using MediatR;

namespace Application.Commands.AddBook
{
    public class AddBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<AddBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository = bookRepository; 

        public Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            // var existingAuthor = _database.Authors.Where(author => author.Id == request.NewBook.Author.Id);
            // Kolla om det finns existerande author eller om en ny ska läggas till

            if (request == null || request.NewBook == null || string.IsNullOrEmpty(request.NewBook.Title))
            {
                return Task.FromResult<Book>(null);
            }

            Book bookToCreate = new Book(Guid.NewGuid(), request.NewBook.Title, request.NewBook.Author, request.NewBook.Description);
            return _bookRepository.AddBook(bookToCreate); 
        }
    }
}
