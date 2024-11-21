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
            Book bookToUpdate = new Book(request.Id, request.Title, request.Author, request.Description); 
            return _database.UpdateBook(bookToUpdate);
        }
    }
}
