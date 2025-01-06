using FluentValidation;

namespace Application.Commands.BookCopyCommands.AddBookCopy
{
    public class AddBookCopyCommandValidator : AbstractValidator<AddBookCopyCommand>
    {
        public AddBookCopyCommandValidator()
        {
            RuleFor(x => x.Dto)
                .NotNull()
                .WithMessage("BookCopy can't be null.");

            RuleFor(x => x.Dto.BookId)
                .NotEmpty()
                .WithMessage("BookId is required.");

            RuleFor(x => x.Dto.FilePath)
                .MaximumLength(250).WithMessage("FilePath must be shorter than 250 characters.");
        }
    }
}
