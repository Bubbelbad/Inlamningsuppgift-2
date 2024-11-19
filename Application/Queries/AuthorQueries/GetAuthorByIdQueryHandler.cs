using Infrastructure.Database;
using MediatR;
using Domain.Model;
using Application.Queries.AuthorQueries;

namespace Application.Queries.AuthorQueries
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly FakeDatabase _database;

        public GetAuthorByIdQueryHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            Author wantedAuthor = _database.Authors.FirstOrDefault(author => author.Id == request.Id)!;
            return Task.FromResult(wantedAuthor);
        }
    }
}
