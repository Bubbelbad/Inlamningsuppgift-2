using Domain.Entities.Core;
namespace Application.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<User> GetDetailedUserById(string id);
        Task<User> LogInUser(string username, string password);
        Task<User> GetUserByUsername(string username);
    }
}
