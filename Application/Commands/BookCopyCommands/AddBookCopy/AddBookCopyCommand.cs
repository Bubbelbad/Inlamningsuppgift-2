using Application.Dtos.BookCopyDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.BookCopyCommands.AddBookCopy
{
    public class AddBookCopyCommand(AddBookCopyDto dto) : IRequest<OperationResult<GetBookCopyDto>>
    {
        public AddBookCopyDto Dto { get; set; } = dto;
    }
}
