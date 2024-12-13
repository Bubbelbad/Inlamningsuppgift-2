using Application.Dtos.UserDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersQuery() : IRequest<OperationResult<List<GetUserDto>>>
    {

    }
}
