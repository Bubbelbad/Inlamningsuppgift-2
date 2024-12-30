using Application.Dtos.ReviewDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.ReviewQueries.GetReviewById
{
    public class GetReviewByIdQuery(int id) : IRequest<OperationResult<GetReviewDto>>
    {
        public int Id { get; set; } = id;
    }
}
