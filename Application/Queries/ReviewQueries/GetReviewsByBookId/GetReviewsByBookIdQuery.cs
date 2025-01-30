using Application.Dtos.ReviewDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.ReviewQueries.GetReviewsByBookId
{
    public class GetReviewsByBookIdQuery(Guid bookId) : IRequest<OperationResult<List<GetBookReviewsDto>>>
    {
        public Guid BookId { get; set; } = bookId;
    }
}
