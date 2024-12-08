using Domain.Model;
using MediatR;

namespace Application.Queries.UserQueries.GetUserByUsername
{
    public class GetUserByUsernameQuery(string username) : IRequest<OperationResult<User>>
    {
        public string Username { get; set; } = username;
    }
}
