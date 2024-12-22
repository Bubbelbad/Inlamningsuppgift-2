using Application.Dtos.BookCopyDtos;
using Application.Dtos.BookDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.BookCopyCommands.AddBookCopy
{
    public class AddBookCopyCommand(AddBookCopyDto dto) : IRequest<OperationResult<GetBookDto>>
    {
        public AddBookCopyDto Dto { get; set; } = dto;
    }
}
