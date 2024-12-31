using Application.Dtos.ReviewDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.ReviewCommands.AddReview
{
    public class AddReviewCommand(AddReviewDto dto) : IRequest<OperationResult<GetReviewDto>>
    {
        public AddReviewDto dto { get; set; } = dto;
    }
}
