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

            RuleFor(x => x.Dto.BranchId)
                .NotEmpty()
                .WithMessage("BranchId is required.");
        }
    }
}
