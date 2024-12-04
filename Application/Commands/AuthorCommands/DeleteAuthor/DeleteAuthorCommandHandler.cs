using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using MediatR;

namespace Application.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper) : IRequestHandler<DeleteAuthorCommand, OperationResult<bool>>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        public IMapper _mapper = mapper; 


        public async Task<OperationResult<bool>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request.Id.Equals(Guid.Empty))
            {
                return OperationResult<bool>.Failure("Id can not be empty");
            }

            try
            {
                var successfulDeletion = await _authorRepository.DeleteAuthor(request.Id);

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
