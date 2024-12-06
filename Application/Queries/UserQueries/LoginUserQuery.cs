using Application.Dtos;
using MediatR;


namespace Application.Queries.UserQueries
{
    public class LoginUserQuery(UserDto loginUser) : IRequest<string>
    {
        public UserDto LoginUser { get; set; } = loginUser;
    }
}
