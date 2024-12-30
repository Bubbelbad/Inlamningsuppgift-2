
using Application.Models;
using MediatR;

namespace Application.Commands.ReviewCommands.DeleteReview
{
    public class DeleteReviewCommand(int id) : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; } = id;
    }
}
