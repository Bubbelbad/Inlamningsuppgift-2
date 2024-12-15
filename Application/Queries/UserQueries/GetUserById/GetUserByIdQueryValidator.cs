using FluentValidation;

namespace Application.Queries.UserQueries.GetUserById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("UserId is required")
                .NotNull().WithMessage("UserId is required");
        }
    }
}
