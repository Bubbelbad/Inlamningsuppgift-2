using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class UserRepository(RealDatabase database) : IUserRepository
    {
        private readonly RealDatabase _realDatabase = database;
        public async Task<List<User>> GetAllUsers()
        {
            List<User> allUsersFromDatabase = _realDatabase.Users.ToList();
            return allUsersFromDatabase;
        }
        public async Task<User> GetUserById(Guid id)
        {
            User user = _realDatabase.Users.FirstOrDefault(user => user.Id == id.ToString());
            return user;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            User user = _realDatabase.Users.FirstOrDefault(user => user.UserName == username);
            return user;
        }

        public Task<User> AddUser(User user)
        {
            _realDatabase.Users.Add(user);
            _realDatabase.SaveChanges();
            return Task.FromResult(user);
        }

        public async Task<User> UpdateUser(User user)
        {
            User userToUpdate = _realDatabase.Users.FirstOrDefault(obj => obj.Id == user.Id);
            if (userToUpdate is not null)
            {
                userToUpdate.UserName = user.UserName;
                userToUpdate.PasswordHash = user.PasswordHash;
                _realDatabase.SaveChanges();
            }
            return userToUpdate;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            bool actionSuccessful = false;
            User? userToDelete = _realDatabase.Users.FirstOrDefault(obj => obj.Id == id.ToString());
            if (userToDelete is not null)
            {
                _realDatabase.Users.Remove(userToDelete);
                _realDatabase.SaveChanges();
                actionSuccessful = true;
            }
            return actionSuccessful;
        }


        public Task<User> LogInUser(string password, string username)
        {
            User user = _realDatabase.Users.FirstOrDefault(user => user.UserName == username && user.PasswordHash == password);
            return Task.FromResult(user);
        }
    }
}
