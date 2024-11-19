using Domain.Model;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Book>
    {
        private readonly FakeDatabase _database; 

        public AddBookCommandHandler(FakeDatabase database)
        {
            _database = database; 
        }

        public Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            Book bookToCreate = new Book(new Guid(), request.NewBook.Title, request.NewBook.Author, request.NewBook.Description);
            return _database.AddNewBook(bookToCreate); 
        }
    }
}
