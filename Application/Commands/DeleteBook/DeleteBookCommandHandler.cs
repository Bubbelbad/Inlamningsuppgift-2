using Domain.Model;
using Infrastructure.Database;
using MediatR;


namespace Application.Commands.DeleteBook
{
    internal sealed class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly FakeDatabase _database;

        public DeleteBookCommandHandler(FakeDatabase database)
        {
            _database = database; 
        }

        public Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return _database.DeleteBook(request.bookIdToDelete);
        }
    }
}
