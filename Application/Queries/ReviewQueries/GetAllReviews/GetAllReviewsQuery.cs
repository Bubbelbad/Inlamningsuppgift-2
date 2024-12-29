using Application.Dtos.ReviewDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.ReviewQueries.GetAllReviews
{
    public class GetAllReviewsQuery() : IRequest<OperationResult<List<GetReviewDto>>>
    {

    }
}
