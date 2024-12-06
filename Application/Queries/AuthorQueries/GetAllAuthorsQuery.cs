using Domain.Model;
using MediatR;

namespace Application.Queries.AuthorQueries
{
    public class GetAllAuthorsQuery() : IRequest<OperationResult<List<Author>>>
    {

    }
}
