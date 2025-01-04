using Application.Dtos.BorrowingDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.BorrowingCommands.ReturnBookCopy
{
    public class ReturnBookCopyCommand(int borrowId) : IRequest<OperationResult<GetBorrowingDto>>
    {
        public int BorrowId { get; set; } = borrowId;
    }
}
