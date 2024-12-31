
using FluentValidation;

namespace Application.Commands.ReviewCommands.UpdateReview
{
    public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewCommandValidator()
        {
            RuleFor(x => x.dto.ReviewId)
                .NotEmpty().WithMessage("ReviewId can not be empty");

            RuleFor(x => x.dto.Comment)
                .NotEmpty().WithMessage("Comment can not be empty");

            RuleFor(x => x.dto.Rating)
                .NotEmpty().WithMessage("Rating betwen 1 - 5 is required.");

            // More stuff here. 
        }
    }
}
