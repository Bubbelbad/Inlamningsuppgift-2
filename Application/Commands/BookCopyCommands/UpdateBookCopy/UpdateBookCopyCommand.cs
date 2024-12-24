using Application.Dtos.BookCopyDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.BookCopyCommands.UpdateBookCopy
{
    public class UpdateBookCopyCommand(UpdateBookCopyDto dto) : IRequest<OperationResult<GetBookCopyDto>>
    {
        public UpdateBookCopyDto Dto { get; set; } = dto;
    }
}
