using FluentValidation;

namespace Application.Commands.BookCopyCommands.DeleteBookCopy
{
    public class DeleteBookCopyCommandValidator : AbstractValidator<DeleteBookCopyCommand>
    {
        public DeleteBookCopyCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required.");
        }
    }
}
