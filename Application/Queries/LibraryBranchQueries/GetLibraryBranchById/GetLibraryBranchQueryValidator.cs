using FluentValidation;

namespace Application.Queries.LibraryBranchQueries.GetLibraryBranchById
{
    public class GetLibraryBranchQueryValidator : AbstractValidator<GetLibraryBranchByIdQuery>
    {
        public GetLibraryBranchQueryValidator()
        {
            RuleFor(x => x.Id)
                .Must(id => id != 0).WithMessage("Id is required, cannot be empty.");
        }
    }
}
