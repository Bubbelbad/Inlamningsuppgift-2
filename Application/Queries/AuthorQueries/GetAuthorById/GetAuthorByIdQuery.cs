using MediatR;
using Domain.Entities.Core;
using Application.Models;

namespace Application.Queries.AuthorQueries.GetAuthorById
{
    public class GetAuthorByIdQuery(Guid authorId) : IRequest<OperationResult<Author>>
    {
        public Guid Id { get; } = authorId;
    }
}
