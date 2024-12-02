using Application.Interfaces.RepositoryInterfaces;
using MediatR;

namespace Application.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler(IAuthorRepository authorRepository) : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;


        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }
            try
            {
                var deletedAuthor = await _authorRepository.DeleteAuthor(request.Id);
                return deletedAuthor; 
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred.", ex);
            }
        }
    }
}
