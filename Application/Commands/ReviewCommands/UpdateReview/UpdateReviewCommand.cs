using Application.Dtos.ReviewDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.ReviewCommands.UpdateReview
{
    public class UpdateReviewCommand(UpdateReviewDto dto) : IRequest<OperationResult<GetReviewDto>>
    {
        public UpdateReviewDto dto { get; set; } = dto;
    }
}
