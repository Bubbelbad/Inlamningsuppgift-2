using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using MediatR;

namespace Application.Commands.UserCommands.AddUser
{
    public class AddNewUserCommandHandler(IUserRepository userRepository) : IRequestHandler<AddNewUserCommand, User>
    {
        private readonly IUserRepository _userReposiory = userRepository;

        public Task<User> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
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

                _userReposiory.AddUser(userToCreate);
                return Task.FromResult(userToCreate);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
