
using Application.Dtos.GenreDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.GenreCommands.DeleteGenre
{
    public class DeleteGenreCommand(int id) : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; } = id;
    }
}
