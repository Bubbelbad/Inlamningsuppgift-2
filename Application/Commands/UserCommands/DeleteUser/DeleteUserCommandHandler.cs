using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.UserCommands.DeleteUser
{
    internal class DeleteUserCommandHandler(IGenericRepository<User, string> repository, IMapper mapper) : IRequestHandler<DeleteUserCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<User, string> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool userToDelete = await _repository.DeleteAsync(request.Id.ToString());
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
