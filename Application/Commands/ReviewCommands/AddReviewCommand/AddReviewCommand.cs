using Application.Dtos.ReviewDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.ReviewCommands.AddReviewCommand
{
    public class AddReviewCommand(AddReviewDto dto) : IRequest<OperationResult<GetReviewDto>>
    {
        public AddReviewDto dto { get; set; } = dto;
    }
}
