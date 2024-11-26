using Infrastructure.Database;
using MediatR;

namespace Application.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler(FakeDatabase database) : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly FakeDatabase _database = database;


        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }

            try
            {
                return await _database.DeleteAuthor(request.Id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred.", ex);
            }
        }
    }
}
