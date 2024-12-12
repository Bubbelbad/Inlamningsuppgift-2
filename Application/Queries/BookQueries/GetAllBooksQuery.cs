using Application.Models;
using Domain.Entities.Core;
using MediatR;

namespace Application.Queries.BookQueries
{
    public class GetAllBooksQuery() : IRequest<OperationResult<List<Book>>>
    {

    }
}
