using Domain.Model;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.AddAuthorCommands.AddAuthor
{
    public class AddAuthorCommandHandler(FakeDatabase database) : IRequestHandler<AddAuthorCommand, Author>
    {
        private readonly FakeDatabase _database = database;

        public Task<Author> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.NewAuthor == null || string.IsNullOrEmpty(request.NewAuthor.FirstName))
            {
                return Task.FromResult<Author>(null);
            }

            Author authorToCreate = new Author(Guid.NewGuid(), request.NewAuthor.FirstName, request.NewAuthor.LastName);
            return _database.AddNewAuthor(authorToCreate);
        }
    }
}