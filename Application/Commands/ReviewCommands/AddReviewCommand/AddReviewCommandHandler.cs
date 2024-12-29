using Application.Dtos.ReviewDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Commands.ReviewCommands.AddReviewCommand
{
    public class AddReviewCommandHandler(IGenericRepository<Review, int> repository, IMapper mapper) : IRequestHandler<AddReviewCommand, OperationResult<GetReviewDto>>
    {
        private readonly IGenericRepository<Review, int> _repository = repository;
        private readonly IMapper _mapper = mapper;


        public async Task<OperationResult<GetReviewDto>> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Review review = new()
                {
                    Rating = request.dto.Rating,
                    Comment = request.dto.Comment,
                    ReviewDate = request.dto.ReviewDate,
                    BookId = request.dto.BookId
                };

                var createdReview = await _repository.AddAsync(review);
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
