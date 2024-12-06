using Domain.Model;
using MediatR;

namespace Application.Commands.DeleteBook
{
    public class DeleteBookCommand(Guid id) : IRequest<OperationResult<bool>>
    {
        public Guid bookIdToDelete { get; } = id;
    }
}
