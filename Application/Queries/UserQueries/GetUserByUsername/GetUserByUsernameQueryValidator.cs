using FluentValidation;

namespace Application.Queries.UserQueries.GetUserByUsername
{
    public class GetUserByUsernameQueryValidator : AbstractValidator<GetUserByUsernameQuery>
    {
        public GetUserByUsernameQueryValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required")
                .NotNull().WithMessage("Username is required");
        }
    }
}
