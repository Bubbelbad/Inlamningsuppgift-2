using Application.Commands.UpdateBook;
using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using MediatR;

namespace Application.Commands.AuthorCommands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler(IAuthorRepository authorRepository) : IRequestHandler<UpdateAuthorCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;

        public Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.NewAuthor == null || string.IsNullOrEmpty(request.NewAuthor.FirstName))
            {
                return Task.FromResult<Author>(null);
            }

            try
            {
                Author authorToUpdate = new Author(request.NewAuthor.Id, request.NewAuthor.FirstName, request.NewAuthor.LastName);
                return _authorRepository.UpdateAuthor(authorToUpdate);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred.", ex);
            }
        }
    }
}
