using Infrastructure.Database;
using MediatR;
using Domain.Model;
using Application.Queries.AuthorQueries;

namespace Application.Queries.AuthorQueries
{
    public class GetAuthorByIdQueryHandler(FakeDatabase database) : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly FakeDatabase _database = database;


        public Task<Author> Handle(GetAuthorByIdQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query), "Query can not be null");
            }

            try
            {
                Author wantedAuthor = _database.Authors.FirstOrDefault(author => author.Id == query.Id)!;
                return Task.FromResult(wantedAuthor);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
