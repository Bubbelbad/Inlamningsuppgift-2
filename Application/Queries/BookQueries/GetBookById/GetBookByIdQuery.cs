using MediatR;
using Application.Models;
using Application.Dtos.BookDtos;

namespace Application.Queries.BookQueries.GetBookById
{
    public class GetBookByIdQuery(Guid bookId) : IRequest<OperationResult<GetBookDto>>
    {
        public Guid Id { get; } = bookId;
    }
}
