using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using MediatR;

namespace Application.Commands.AuthorCommands.AddAuthor
{
    public class AddAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper) : IRequestHandler<AddAuthorCommand, OperationResult<Author>>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        public IMapper _mapper = mapper;

        public async Task<OperationResult<Author>> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.NewAuthor == null || string.IsNullOrEmpty(request.NewAuthor.FirstName))
            {
                return OperationResult<Author>.Failure("Invalid input");
            }

            try
            {
                var authorToCreate = new Author(Guid.NewGuid(), request.NewAuthor.FirstName, request.NewAuthor.LastName);
                var createdAutor = await _authorRepository.AddAuthor(authorToCreate);
                var mappedAuthor = _mapper.Map<Author>(createdAutor);
                return OperationResult<Author>.Success(mappedAuthor);
            }
            catch
            {
                throw new Exception("Author not added");
            }
        }
    }
}