
using FluentValidation;

namespace Application.Queries.ReviewQueries.GetReviewById
{
    public class GetReviewByIdQueryValidator : AbstractValidator<GetReviewByIdQuery>
    {
        public GetReviewByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id can not be empty");
        }
    }
}
