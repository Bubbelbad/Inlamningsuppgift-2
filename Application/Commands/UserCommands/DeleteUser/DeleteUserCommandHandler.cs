using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Commands.UserCommands.DeleteUser
{
    internal class DeleteUserCommandHandler(IUserRepository repository, IMapper mapper) : IRequestHandler<DeleteUserCommand, OperationResult<bool>>
    {
        private readonly IUserRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                return OperationResult<bool>.Failure("User Id is required");
            }

            try
            {
                bool userToDelete = await _repository.DeleteUser(request.Id);
                var mappedBool = _mapper.Map<bool>(userToDelete);
                if (userToDelete)
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
