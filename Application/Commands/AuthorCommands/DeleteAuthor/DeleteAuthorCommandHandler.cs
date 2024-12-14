using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper) : IRequestHandler<DeleteAuthorCommand, OperationResult<bool>>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        public IMapper _mapper = mapper;


        public async Task<OperationResult<bool>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
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
