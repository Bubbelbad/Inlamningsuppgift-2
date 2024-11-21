using Infrastructure.Database;
using MediatR;
using Domain.Model;

namespace Application.Queries.BookQueries
{
    public class GetBookByIdQueryHandler(FakeDatabase database) : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly FakeDatabase _database = database;

      
        public Task<Book> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query), "Query cannot be null.");
            }

            try
            {
                Book wantedBook = _database.Books.FirstOrDefault(book => book.Id == query.Id)!;
                return Task.FromResult(wantedBook);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
