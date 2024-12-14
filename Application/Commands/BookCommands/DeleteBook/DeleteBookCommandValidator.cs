using FluentValidation;

namespace Application.Commands.BookCommands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x => x.BookIdToDelete)
                .Must(id => id != System.Guid.Empty).WithMessage("Id is required, cannot be empty.");
        }
    }
}
