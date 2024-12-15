using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler(IGenericRepository<Author, Guid> repository, IMapper mapper) : IRequestHandler<DeleteAuthorCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<Author, Guid> _repository = repository;
        public IMapper _mapper = mapper;


        public async Task<OperationResult<bool>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var successfulDeletion = await _repository.DeleteAsync(request.Id);
                var mappedBool = _mapper.Map<bool>(successfulDeletion);

                if (successfulDeletion)
                {
                    return OperationResult<bool>.Success(mappedBool);
                }
                return OperationResult<bool>.Failure("Operation failed");
            }

            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred.", ex);
            }
        }
    }
}
