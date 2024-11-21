using Application.Dtos;
using Domain.Model;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly FakeDatabase _database;

        public UpdateBookCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.NewBook == null || string.IsNullOrEmpty(request.NewBook.Title))
            {
                return Task.FromResult<Book>(null);
            }

            Book bookToUpdate = new Book(request.NewBook.Id, request.NewBook.Title, request.NewBook.Author, request.NewBook.Description); 
            return _database.UpdateBook(bookToUpdate);
        }
    }
}
