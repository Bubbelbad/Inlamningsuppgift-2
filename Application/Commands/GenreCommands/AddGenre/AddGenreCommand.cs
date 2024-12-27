using Application.Dtos.GenreDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.GenreCommands.AddGenre
{
    public class AddGenreCommand(AddGenreDto dto) : IRequest<OperationResult<GetGenreDto>>
    {
        public AddGenreDto Dto { get; set; } = dto;
    }
}
