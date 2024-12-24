using Application.Models;
using MediatR;

namespace Application.Commands.BookCopyCommands.DeleteBookCopy
{
    public class DeleteBookCopyCommand(Guid id) : IRequest<OperationResult<bool>>
    {
        public Guid Id { get; set; } = id;
    }
}
