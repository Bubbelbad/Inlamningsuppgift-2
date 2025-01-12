using Application.Dtos.AuthorDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.AuthorCommands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler(IGenericRepository<Author, Guid> repository, IMapper mapper) : IRequestHandler<UpdateAuthorCommand, OperationResult<GetAuthorDto>>
    {
        private readonly IGenericRepository<Author, Guid> _repository = repository;
        public IMapper _mapper = mapper;

        public async Task<OperationResult<GetAuthorDto>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var authorToUpdate = await _repository.GetByIdAsync(request.NewAuthor.AuthorId);
                if (authorToUpdate is null)
                {
                    return OperationResult<GetAuthorDto>.Failure("Author not found.");
                }

                authorToUpdate.FirstName = request.NewAuthor.FirstName;
                authorToUpdate.LastName = request.NewAuthor.LastName;
                authorToUpdate.DateOfBirth = request.NewAuthor.DateOfBirth;
                authorToUpdate.Biography = request.NewAuthor.Biography;

                var updatedAuthor = await _repository.UpdateAsync(authorToUpdate);
                var mappedAuthor = _mapper.Map<GetAuthorDto>(updatedAuthor);
                return OperationResult<GetAuthorDto>.Success(mappedAuthor);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred.", ex);
            }
        }
    }
}
