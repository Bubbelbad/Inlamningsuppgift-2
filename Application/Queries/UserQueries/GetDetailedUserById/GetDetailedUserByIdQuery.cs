using Application.Models;
using Domain.Entities.Core;
using MediatR;


namespace Application.Queries.UserQueries.GetDetailedUserById
{
    public class GetDetailedUserByIdQuery(string id) : IRequest<OperationResult<User>>
    {
        public string Id { get; set; } = id;
    }
}
