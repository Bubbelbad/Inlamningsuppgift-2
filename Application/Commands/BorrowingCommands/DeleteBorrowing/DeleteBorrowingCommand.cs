using Application.Models;
using MediatR;

namespace Application.Commands.BorrowingCommands.DeleteBorrowing
{
    public class DeleteBorrowingCommand(int id) : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; } = id;
    }
}
