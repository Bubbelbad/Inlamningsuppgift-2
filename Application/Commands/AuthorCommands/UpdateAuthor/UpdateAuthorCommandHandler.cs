using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.AuthorCommands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper) : IRequestHandler<UpdateAuthorCommand, OperationResult<Author>>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        public IMapper _mapper = mapper;

        public async Task<OperationResult<Author>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Author authorToUpdate = new()
                {
                    AuthorId = request.NewAuthor.AuthorId,
                    FirstName = request.NewAuthor.FirstName,
                    LastName = request.NewAuthor.LastName,
                    DateOfBirth = request.NewAuthor.DateOfBirth,
                    Biography = request.NewAuthor.Biography
                };

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
