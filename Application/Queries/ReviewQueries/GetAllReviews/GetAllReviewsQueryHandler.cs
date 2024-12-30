using Application.Dtos.ReviewDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Queries.ReviewQueries.GetAllReviews
{
    public class GetAllReviewsQueryHandler(IGenericRepository<Review, int> repository, IMapper mapper) : IRequestHandler<GetAllReviewsQuery, OperationResult<List<GetReviewDto>>>
    {
        private readonly IGenericRepository<Review, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<List<GetReviewDto>>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allReviews = await _repository.GetAllAsync();
                if (allReviews is null)
                {
                    return OperationResult<List<GetReviewDto>>.Failure("Operation failed");
                }
                var mappedReviews = _mapper.Map<List<GetReviewDto>>(allReviews);
                return OperationResult<List<GetReviewDto>>.Success(mappedReviews);
            }
            catch (Exception ex)
            {
                return OperationResult<List<GetReviewDto>>.Failure(ex.Message, ex.InnerException.Message);
            }
        }
    }
}
