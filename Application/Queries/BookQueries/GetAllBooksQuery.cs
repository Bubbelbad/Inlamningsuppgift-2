using Domain.Model;
using MediatR;

namespace Application.Queries.BookQueries
{
    public class GetAllBooksQuery() : IRequest<OperationResult<List<Book>>>
    {

    }
}
