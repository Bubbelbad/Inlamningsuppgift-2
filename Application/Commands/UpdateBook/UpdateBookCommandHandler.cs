using Domain.Model;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.UpdateBook
{
    internal sealed class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly FakeDatabase _database;

        public UpdateBookCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Book bookToUpdate = new Book(request.UpdatedBook.Id, request.UpdatedBook.Title, request.UpdatedBook.Author, request.UpdatedBook.Description);
            return _database.UpdateBook(bookToUpdate);
        }
    }
}
