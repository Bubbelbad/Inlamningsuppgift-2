using Application.Commands.UpdateBook;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using MediatR;

namespace Application.Commands.AuthorCommands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper) : IRequestHandler<UpdateAuthorCommand, OperationResult<Author>>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        public IMapper _mapper = mapper; 

        public async Task<OperationResult<Author>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.NewAuthor == null || string.IsNullOrEmpty(request.NewAuthor.FirstName))
            {
                return OperationResult<Author>.Failure("Not valid input"); 
            }

            try
            {
                var authorToUpdate = new Author(request.NewAuthor.Id, request.NewAuthor.FirstName, request.NewAuthor.LastName);
                var updatedAuthor = await _authorRepository.UpdateAuthor(authorToUpdate);
                var mappedAuthor = _mapper.Map<Author>(updatedAuthor);

                return OperationResult<Author>.Success(mappedAuthor); 
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred.", ex);
            }
        }
    }
}
