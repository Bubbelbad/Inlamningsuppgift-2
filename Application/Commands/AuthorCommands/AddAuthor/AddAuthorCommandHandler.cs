using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using MediatR;

namespace Application.Commands.AddAuthorCommands.AddAuthor
{
    public class AddAuthorCommandHandler(IAuthorRepository authorRepository) : IRequestHandler<AddAuthorCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;

        public Task<Author> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.NewAuthor == null || string.IsNullOrEmpty(request.NewAuthor.FirstName))
            {
                return Task.FromResult<Author>(null);
            }
            try
            {
                Author authorToCreate = new(Guid.NewGuid(), request.NewAuthor.FirstName, request.NewAuthor.LastName);
                return _authorRepository.AddAuthor(authorToCreate);
            }
            catch
            {
                throw new Exception("Author not added"); 
            }

        }
    }
}