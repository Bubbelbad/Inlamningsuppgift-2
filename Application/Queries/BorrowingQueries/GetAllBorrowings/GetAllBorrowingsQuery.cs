
using Application.Dtos.BorrowingDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.BorrowingQueries.GetAllBorrowings
{
    public class GetAllBorrowingsQuery() : IRequest<OperationResult<List<GetBorrowingDto>>>
    {
    }
}
