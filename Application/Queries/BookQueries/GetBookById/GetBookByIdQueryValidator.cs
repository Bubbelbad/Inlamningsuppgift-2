using FluentValidation;

namespace Application.Queries.BookQueries.GetBookById
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .Must(id => id != System.Guid.Empty).WithMessage("Id is required, cannot be empty.");
        }
    }
}
