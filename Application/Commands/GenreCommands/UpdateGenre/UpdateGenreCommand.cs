using Application.Dtos.GenreDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.GenreCommands.UpdateGenre
{
    public class UpdateGenreCommand(UpdateGenreDto dto) : IRequest<OperationResult<GetGenreDto>>
    {
        public UpdateGenreDto Dto { get; set; } = dto;
    }
}
