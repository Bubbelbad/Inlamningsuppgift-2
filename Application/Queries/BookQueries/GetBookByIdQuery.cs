using MediatR;
using Domain.Model;

namespace Application.Queries.BookQueries
{
    public class GetBookByIdQuery(Guid bookId) : IRequest<OperationResult<Book>>
    {
        public Guid Id { get; } = bookId;
    }
}
