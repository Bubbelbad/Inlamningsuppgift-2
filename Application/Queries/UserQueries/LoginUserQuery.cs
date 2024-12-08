using Application.Dtos;
using MediatR;


namespace Application.Queries.UserQueries
{
    public class LoginUserQuery(string username, string password) : IRequest<string>
    {
        public string Username { get; set; } = username;
        public string password { get; set; } = password;
    }
}
