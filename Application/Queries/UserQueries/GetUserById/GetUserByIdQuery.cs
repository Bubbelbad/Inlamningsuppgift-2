using Application.Dtos.UserDtos;
using Domain.Model;
using MediatR;

namespace Application.Queries.UserQueries.GetUserById
{
    public class GetUserByIdQuery(Guid id) : IRequest<OperationResult<GetUserDto>>
    {
        public Guid Id { get; set; } = id;
    }
}
