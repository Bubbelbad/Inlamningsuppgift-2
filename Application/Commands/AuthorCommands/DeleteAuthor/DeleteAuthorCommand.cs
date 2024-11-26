using MediatR;

namespace Application.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorCommand(Guid authorId) : IRequest<bool>
    {
        public Guid Id { get; set; } = authorId; 
    }
}
