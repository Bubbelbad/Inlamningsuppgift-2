
using Application.Dtos.GenreDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.GenreQueries.GetAllGenres
{
    public class GetAllGenresQuery() : IRequest<OperationResult<List<GetGenreDto>>>
    {
    }
}
