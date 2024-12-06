using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using MediatR;

namespace Application.Commands.UserCommands.AddUser
{
    public class AddNewUserCommandHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<AddNewUserCommand, OperationResult<User>>
    {
        private readonly IUserRepository _userReposiory = userRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<User>> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request or LoginUser cannot be null.");
            }

            try
            {
                User userToCreate = new()
                {
                    Id = Guid.NewGuid(),
                    UserName = request.NewUser.UserName,
                    Password = request.NewUser.Password
                };

                var createdUser = await _userReposiory.AddUser(userToCreate);
                var mappedUser = _mapper.Map<User>(createdUser);
                return OperationResult<User>.Success(mappedUser);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
