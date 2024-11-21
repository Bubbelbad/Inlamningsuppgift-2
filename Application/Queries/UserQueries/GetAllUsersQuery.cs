using Domain.Model;
using MediatR;

namespace Application.Queries.UserQueries
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {

    }
}
