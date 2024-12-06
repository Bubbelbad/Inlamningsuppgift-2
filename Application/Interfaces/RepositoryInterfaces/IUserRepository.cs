using Domain.Model;
namespace Application.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> LogInUser(string username, string password);
        Task<bool> DeleteUser(Guid id);
    }
}
