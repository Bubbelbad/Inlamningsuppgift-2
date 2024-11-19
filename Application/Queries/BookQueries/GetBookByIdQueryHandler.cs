using Infrastructure.Database;
using MediatR;
using Domain.Model;

namespace Application.Queries.BookQueries
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly FakeDatabase _database;

        public GetBookByIdQueryHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            Book wantedBook = _database.Books.FirstOrDefault(book => book.Id == request.Id)!;
            return Task.FromResult(wantedBook);
        }
    }
}
