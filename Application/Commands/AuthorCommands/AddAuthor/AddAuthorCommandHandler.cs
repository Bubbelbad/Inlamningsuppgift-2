using Domain.Model;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.AddAuthorCommands.AddAuthor
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, Author>
    {
        private readonly FakeDatabase _database;

        public AddAuthorCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<Author> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            // var existingAuthor = _database.Authors.Where(author => author.Id == request.NewBook.Author.Id);
            // Kolla om det finns existerande author eller om en ny ska läggas till
            if (request == null || request.NewAuthor == null || string.IsNullOrEmpty(request.NewAuthor.FirstName))
            {
                return Task.FromResult<Author>(null);
            }
            Author authorToCreate = new Author(Guid.NewGuid(), request.NewAuthor.FirstName, request.NewAuthor.LastName);
            return _database.AddNewAuthor(authorToCreate);
        }
    }
}