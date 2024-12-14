
using FluentValidation;

namespace Application.Queries.AuthorQueries.GetAuthorById
{
    public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
    {
        public GetAuthorByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .Must(id => id != System.Guid.Empty).WithMessage("Id is required, cannot be empty.");
        }
    }
}
