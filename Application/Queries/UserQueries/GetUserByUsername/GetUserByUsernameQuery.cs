using Application.Dtos.UserDtos;
using Application.Models;
using Domain.Entities.Core;
using MediatR;

namespace Application.Queries.UserQueries.GetUserByUsername
{
    public class GetUserByUsernameQuery(string username) : IRequest<OperationResult<GetUserByUserNameDto>>
    {
        public string Username { get; set; } = username;
    }
}
