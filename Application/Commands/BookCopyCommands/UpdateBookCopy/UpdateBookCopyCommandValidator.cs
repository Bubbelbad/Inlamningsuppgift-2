
using FluentValidation;

namespace Application.Commands.BookCopyCommands.UpdateBookCopy
{
    public class UpdateBookCopyCommandValidator : AbstractValidator<UpdateBookCopyCommand>
    {
        public UpdateBookCopyCommandValidator()
        {
            RuleFor(x => x.Dto.CopyId)
                .NotNull()
                .WithMessage("Id can't be null.");

            RuleFor(x => x.Dto.BookId)
                .NotEmpty()
                .WithMessage("BookId is required.");

            RuleFor(x => x.Dto.BranchId)
                .NotEmpty()
                .WithMessage("BranchId is required.");

            RuleFor(x => x.Dto.Status)
                .NotEmpty()
                .WithMessage("Status is required.");
        }
    }
}
