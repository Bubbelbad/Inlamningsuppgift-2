using Application.Dtos.ReviewDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Commands.ReviewCommands.UpdateReview
{
    public class UpdateReviewCommandHandler(IGenericRepository<Review, int> repository, IMapper mapper) : IRequestHandler<UpdateReviewCommand, OperationResult<GetReviewDto>>
    {
        private readonly IGenericRepository<Review, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetReviewDto>> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Review review = new()
                {
                    Id = request.dto.ReviewId,
                    Rating = request.dto.Rating,
                    Comment = request.dto.Comment,
                    ReviewDate = request.dto.ReviewDate,
                    BookId = request.dto.BookId
                };
                var updatedReview = await _repository.UpdateAsync(review);
                var mappedReview = _mapper.Map<GetReviewDto>(updatedReview);
                return OperationResult<GetReviewDto>.Success(mappedReview);
            }
            catch (Exception ex)
            {
                return OperationResult<GetReviewDto>.Failure(ex.Message, ex.InnerException.Message);
            }
        }
    }
}
