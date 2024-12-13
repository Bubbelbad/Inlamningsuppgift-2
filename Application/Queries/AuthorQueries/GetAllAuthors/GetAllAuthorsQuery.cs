using Application.Models;
using Domain.Entities.Core;
using MediatR;

namespace Application.Queries.AuthorQueries.GetAllAuthors
{
    public class GetAllAuthorsQuery() : IRequest<OperationResult<List<Author>>>
    {

    }
}
