using Application.Dtos.BookDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.BookQueries.GetAllBooks
{
    public class GetAllBooksQuery() : IRequest<OperationResult<List<GetBookDto>>>
    {

    }
}
