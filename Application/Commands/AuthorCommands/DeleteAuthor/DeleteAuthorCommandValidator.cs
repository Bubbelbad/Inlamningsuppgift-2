using FluentValidation;

namespace Application.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(x => x.Id)
                .Must(id => id != Guid.Empty).WithMessage("Id is required, cannot be empty.");
        }
    }
}
