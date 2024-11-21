using Application.Commands.UpdateBook;
using Domain.Model;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AuthorCommands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Author>
    {
        private readonly FakeDatabase _database;

        public UpdateAuthorCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.NewAuthor == null || string.IsNullOrEmpty(request.NewAuthor.FirstName))
            {
                return Task.FromResult<Author>(null);
            }

            Author authorToUpdate = new Author(request.NewAuthor.Id, request.NewAuthor.FirstName, request.NewAuthor.LastName);
            return _database.UpdateAuthor(authorToUpdate); 
        }
    }
}
