using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class UserRepository(RealDatabase database) : IUserRepository
    {
        private readonly RealDatabase _realDatabase = database;

        public Task<User> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> LogInUser(string password, string username)
        {
            User user = _realDatabase.Users.FirstOrDefault(user => user.UserName == username && user.Password == password);
            if (user is not null)
            {
                return Task.FromResult(user);
            }
            return Task.FromResult(user);
        }
    }
}
