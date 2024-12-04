using MediatR;
using Domain.Model;

namespace Application.Queries.AuthorQueries
{
    public class GetAuthorByIdQuery : IRequest<OperationResult<Author>>
    {
        public GetAuthorByIdQuery(Guid authorId)
        {
            Id = authorId;
        }
        public Guid Id { get; }
    }
}
