using FluentValidation;

namespace Application.Commands.AuthorCommands.UpdateAuthor
{
    public class UpdateAuthorCommandValitator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValitator()
        {
            RuleFor(x => x.NewAuthor.AuthorId)
                .Must(id => id != System.Guid.Empty).WithMessage("Id is required, cannot be empty.");

            RuleFor(x => x.NewAuthor.FirstName)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            RuleFor(x => x.NewAuthor.LastName)
                .NotEmpty().WithMessage("Lastaname is required.")
                .MinimumLength(3).WithMessage("Password must be at least 3 characters long.");
        }
    }
}
