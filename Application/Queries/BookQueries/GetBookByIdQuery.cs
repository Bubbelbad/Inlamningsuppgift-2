using MediatR;
using Domain.Entities.Core;
using Application.Models;

namespace Application.Queries.BookQueries
{
    public class GetBookByIdQuery(Guid bookId) : IRequest<OperationResult<Book>>
    {
        public Guid Id { get; } = bookId;
    }
}
