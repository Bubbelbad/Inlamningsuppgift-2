using MediatR;
using Domain.Model;

namespace Application.Queries.BookQueries
{
    public class GetBookByIdQuery : IRequest<OperationResult<Book>>
    {
        public GetBookByIdQuery(Guid bookId)
        {
            Id = bookId;
        }

        public Guid Id { get; }
    }
}
