using Application.Dtos.BookCopyDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.BookCopyQueries.GetAllBookCopies
{
    public class GetAllBookCopiesQuery() : IRequest<OperationResult<List<GetBookCopyDto>>>
    {
    }
}
