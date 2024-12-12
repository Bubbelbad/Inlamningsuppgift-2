using Application.Dtos;
using Application.Dtos.UserDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.UserQueries
{
    public class GetAllUsersQuery() : IRequest<OperationResult<List<GetUserDto>>>
    {

    }
}
