
using Application.Dtos.ReviewDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Queries.ReviewQueries.GetReviewById
{
    public class GetReviewByIdQueryHandler(IGenericRepository<Review, int> repository, IMapper mapper) : IRequestHandler<GetReviewByIdQuery, OperationResult<GetReviewDto>>
    {
        private readonly IGenericRepository<Review, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetReviewDto>> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var review = await _repository.GetByIdAsync(request.Id);
                if (review is null)
                {
                    return OperationResult<GetReviewDto>.Failure("Operation failed");
                }
                var mappedReview = _mapper.Map<GetReviewDto>(review);
                return OperationResult<GetReviewDto>.Success(mappedReview);
            }
            catch (Exception ex)
            {
                return OperationResult<GetReviewDto>.Failure(ex.Message, ex.InnerException.Message);
            }
        }
    }
}
