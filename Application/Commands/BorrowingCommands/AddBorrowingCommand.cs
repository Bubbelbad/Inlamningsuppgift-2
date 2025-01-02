using Application.Dtos.BorrowingDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.BorrowingCommands
{
    public class AddBorrowingCommand(AddBorrowingDto dto) : IRequest<OperationResult<GetBorrowingDto>>
    {
        public AddBorrowingDto Dto { get; set; } = dto;
    }
}
