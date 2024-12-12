using Application.Models;
using Domain.Entities.Core;
using MediatR;


namespace Application.Queries.UserQueries.GetDetailedUserById
{
    public class GetDetailedUserByIdQuery(Guid id) : IRequest<OperationResult<User>>
    {
        public Guid Id { get; set; } = id;
    }
}
