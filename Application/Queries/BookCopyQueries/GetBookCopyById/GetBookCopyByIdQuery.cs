using MediatR;
using Application.Models;
using Application.Dtos.BookCopyDtos;

namespace Application.Queries.BookQueries.GetBookCopyById
{
    public class GetBookCopyByIdQuery(Guid bookId) : IRequest<OperationResult<GetBookCopyDto>>
    {
        public Guid Id { get; } = bookId;
    }
}