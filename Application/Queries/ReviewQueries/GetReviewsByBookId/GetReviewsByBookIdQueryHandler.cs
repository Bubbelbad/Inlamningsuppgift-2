using Application.Dtos.ReviewDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Queries.ReviewQueries.GetReviewsByBookId
{
    internal sealed class GetReviewsByBookIdQueryHandler : IRequestHandler<GetReviewsByBookIdQuery, OperationResult<List<GetBookReviewsDto>>>
    {
        private readonly IGenericRepository<Book, Guid> _bookRepository;
        private readonly IGenericRepository<Review, int> _reviewRepository;
        private readonly IMapper _mapper;

        public GetReviewsByBookIdQueryHandler(
            IGenericRepository<Book, Guid> bookRepository,
            IGenericRepository<Review, int> reviewRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<List<GetBookReviewsDto>>> Handle(GetReviewsByBookIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(request.BookId, b => b.Reviews);
                if (book == null)
                {
                    return OperationResult<List<GetBookReviewsDto>>.Failure("Book not found");
                }

                var reviews = new List<GetBookReviewsDto>();
                foreach (var review in book.Reviews)
                {
                    var thing = await _reviewRepository.GetByIdAsync(review.Id, r => r.User);
                    reviews.Add(_mapper.Map<GetBookReviewsDto>(thing));
                }

                return OperationResult<List<GetBookReviewsDto>>.Success(reviews);
            }
            catch
            {
                return OperationResult<List<GetBookReviewsDto>>.Failure("An error occurred");
            }
        }
    }
}
