using Application.Queries.BookQueries.GetBookCopyById;
using FluentValidation;


namespace Application.Queries.BookCopyQueries.GetBookCopyById
{
    public class GetBookCopyByIdQueryValidator : AbstractValidator<GetBookCopyByIdQuery>
    {
        public GetBookCopyByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .Must(id => id != System.Guid.Empty).WithMessage("Id is required, cannot be empty.");
        }
    }
}
