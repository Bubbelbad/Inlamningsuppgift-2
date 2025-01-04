using Application.Dtos.BorrowingDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.BorrowingQueries.GetBorrowingById
{
    public class GetBorrowingByIdQuery(int id) : IRequest<OperationResult<GetBorrowingDto>>
    {
        public int Id { get; set; } = id;
    }
}
