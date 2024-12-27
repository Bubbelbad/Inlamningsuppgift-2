using Application.Dtos.GenreDtos;
using Application.Models;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Queries.GenreQueries.GetGenreById
{
    public class GetGenreByIdQuery(int id) : IRequest<OperationResult<GetGenreDto>>
    {
        public int Id { get; set; } = id;
    }
}
