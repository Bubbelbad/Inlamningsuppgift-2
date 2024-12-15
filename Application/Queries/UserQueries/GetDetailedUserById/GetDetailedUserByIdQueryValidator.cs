using FluentValidation;

namespace Application.Queries.UserQueries.GetDetailedUserById
{
    public class GetDetailedUserByIdQueryValidator : AbstractValidator<GetDetailedUserByIdQuery>
    {
        public GetDetailedUserByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("UserId is required")
                .NotNull().WithMessage("UserId is required");
        }
    }
}
