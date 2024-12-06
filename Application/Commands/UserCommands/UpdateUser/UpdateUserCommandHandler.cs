using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using MediatR;

namespace Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommandHandler(IUserRepository repository, IMapper mapper) : IRequestHandler<UpdateUserCommand, OperationResult<User>>
    {
        private readonly IUserRepository _userRepository = repository;
        private readonly IMapper _mapper = mapper;


        public async Task<OperationResult<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.UserToUpdate == null)
            {
                throw new ArgumentException("Request or LoginUser cannot be null.");
            }

            try
            {
                User userToUpdate = new()
                {
                    Id = request.UserToUpdate.Id,
                    UserName = request.UserToUpdate.Username,
                    Password = request.UserToUpdate.Password
                };

                var updatedUser = await _userRepository.UpdateUser(userToUpdate);
                var mappedUser = _mapper.Map<User>(updatedUser);
                return OperationResult<User>.Success(mappedUser);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
