using Application.Dtos.BorrowingDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.BorrowingCommands.BorrowBookCopy
{
    public class BorrowBookCopyCommand(BorrowBookDto dto) : IRequest<OperationResult<GetBorrowingDto>>
    {
        public BorrowBookDto Dto { get; set; } = dto;
    }
}
