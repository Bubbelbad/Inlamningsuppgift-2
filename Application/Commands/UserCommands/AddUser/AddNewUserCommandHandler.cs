using Domain.Model;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.UserCommands.AddUser
{
    internal sealed class AddNewUserCommandHandler(FakeDatabase database) : IRequestHandler<AddNewUserCommand, User>
    {
        private readonly FakeDatabase _database = database;

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

                _database.Users.Add(userToCreate);
                return Task.FromResult(userToCreate);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
