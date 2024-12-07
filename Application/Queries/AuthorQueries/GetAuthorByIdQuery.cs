using MediatR;
using Domain.Model;

namespace Application.Queries.AuthorQueries
{
    public class GetAuthorByIdQuery(Guid authorId) : IRequest<OperationResult<Author>>
    {
        public Guid Id { get; } = authorId;
    }
}
