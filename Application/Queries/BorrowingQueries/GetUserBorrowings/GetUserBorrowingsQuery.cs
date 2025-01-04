
using Application.Dtos.BorrowingDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.BorrowingQueries.GetUserBorrowings
{
    public class GetUserBorrowingsQuery(Guid userId) : IRequest<OperationResult<List<GetBorrowingDto>>>
    {
        public string UserId { get; set; } = userId.ToString();
    }
}
