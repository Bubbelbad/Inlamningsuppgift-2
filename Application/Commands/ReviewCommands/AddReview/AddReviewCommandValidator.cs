
using FluentValidation;

namespace Application.Commands.ReviewCommands.AddReview
{
    public class AddReviewCommandValidator : AbstractValidator<AddReviewCommand>
    {
        public AddReviewCommandValidator()
        {
            RuleFor(x => x.dto.Comment)
                .NotEmpty().WithMessage("Comment can not be empty");

            RuleFor(x => x.dto.Rating)
                .NotEmpty().WithMessage("Rating betwen 1 - 5 is required.");

            // More stuff here. 
        }
    }
}
