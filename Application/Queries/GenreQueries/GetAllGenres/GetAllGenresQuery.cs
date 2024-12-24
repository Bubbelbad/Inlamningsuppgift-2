
using Application.Models;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Queries.GenreQueries.GetAllGenres
{
    public class GetAllGenresQuery() : IRequest<OperationResult<List<Genre>>>
    {
    }
}
