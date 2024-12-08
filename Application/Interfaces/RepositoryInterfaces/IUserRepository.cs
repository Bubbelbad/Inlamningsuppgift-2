using Domain.Model;
namespace Application.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByUsername(string username);
        Task<User> AddUser(User user);
        Task<User> LogInUser(string username, string password);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(Guid id);
    }
}
