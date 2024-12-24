using Application.Models;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Queries.GenreQueries.GetGenreById
{
    public class GetGenreByIdQuery(int id) : IRequest<OperationResult<Genre>>
    {
        public int Id { get; set; } = id;
    }
}
