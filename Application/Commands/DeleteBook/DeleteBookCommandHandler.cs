using Domain.Model;
using Infrastructure.Database;
using MediatR;


namespace Application.Commands.DeleteBook
{
    public class DeleteBookCommandHandler(FakeDatabase database) : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly FakeDatabase _database = database;

        public Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }

            try
            {
                return _database.DeleteBook(request.bookIdToDelete);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred.", ex);
            }
        }
    }
}
