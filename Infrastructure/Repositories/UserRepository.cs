using Application.Interfaces.RepositoryInterfaces;
using Domain.Entities.Core;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User, string>, IUserRepository
    {
        private readonly RealDatabase _realDatabase;

        public UserRepository(RealDatabase database) : base(database)
        {
            _realDatabase = database;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            User user = _realDatabase.Users.FirstOrDefault(user => user.UserName == username);
            return user;
        }

        public Task<User> LogInUser(string password, string username)
        {
            User user = _realDatabase.Users.FirstOrDefault(user => user.UserName == username && user.PasswordHash == password);
            return Task.FromResult(user);
        }

        public Task<User> GetDetailedUserById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
