using Domain.Model;
using MediatR;

namespace Application.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorCommand(Guid authorId) : IRequest<OperationResult<bool>>
    {
        public Guid Id { get; set; } = authorId;
    }
}
