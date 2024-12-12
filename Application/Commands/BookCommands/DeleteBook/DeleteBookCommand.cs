using Application.Models;
using MediatR;

namespace Application.Commands.BookCommands.DeleteBook
{
    public class DeleteBookCommand(Guid id) : IRequest<OperationResult<bool>>
    {
        public Guid BookIdToDelete { get; } = id;
    }
}
