using Domain.Model;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly FakeDatabase _database;

        public DeleteAuthorCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            return await _database.DeleteAuthor(request.Id);
        }
    }
}
