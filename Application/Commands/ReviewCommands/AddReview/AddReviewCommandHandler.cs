using Application.Dtos.ReviewDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Commands.ReviewCommands.AddReview
{
    public class AddReviewCommandHandler(IGenericRepository<Review, int> reviewRepository, IGenericRepository<User, string> userRepository, IGenericRepository<Book, Guid> bookRepository, IMapper mapper) : IRequestHandler<AddReviewCommand, OperationResult<GetReviewDto>>
    {
        private readonly IGenericRepository<Review, int> _reviewRepository = reviewRepository;
        private readonly IGenericRepository<User, string> _userRepository = userRepository;
        private readonly IGenericRepository<Book, Guid> _bookRepository = bookRepository;
        private readonly IMapper _mapper = mapper;


        public async Task<OperationResult<GetReviewDto>> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _userRepository.GetByIdAsync(request.dto.UserId.ToString());
                Book book = await _bookRepository.GetByIdAsync(request.dto.BookId);

                Review review = new()
                {
                    Rating = request.dto.Rating,
                    Comment = request.dto.Comment,
                    ReviewDate = request.dto.ReviewDate,
                    BookId = request.dto.BookId,
                    UserId = request.dto.UserId.ToString(),
                    User = user,
                    Book = book,
                };

                var createdReview = await _reviewRepository.AddAsync(review);
                if (createdReview != null)
                {
                    var mappedReview = _mapper.Map<GetReviewDto>(request.dto);
                    return OperationResult<GetReviewDto>.Success(mappedReview);
                }

                return OperationResult<GetReviewDto>.Failure("Review not added");
            }
            catch (Exception ex)
            {
                throw new Exception("Review not added", ex);
            }
        }
    }
}
