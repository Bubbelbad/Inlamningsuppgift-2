using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Commands.ReviewCommands.DeleteReview
{
    internal class DeleteReviewCommandHandler(IGenericRepository<Review, int> repository, IMapper mapper) : IRequestHandler<DeleteReviewCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<Review, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<bool>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deletionSucessful = await _repository.DeleteAsync(request.Id);
                if (deletionSucessful is false)
                {
                    return OperationResult<bool>.Failure("Operation failed");
                }
                return OperationResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Failure(ex.Message, ex.InnerException.Message);
            }

        }
    }
}