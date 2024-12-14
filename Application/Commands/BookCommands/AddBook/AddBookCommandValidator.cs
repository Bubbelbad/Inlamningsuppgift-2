
using FluentValidation;

namespace Application.Commands.BookCommands.AddBook
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator()
        {
            RuleFor(x => x.NewBook.AuthorId)
                .NotNull().WithMessage("AuthorId is required, cannot be null.");

            RuleFor(x => x.NewBook.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(2, 50).WithMessage("Title must be between 2 and 50 characters.");

            RuleFor(x => x.NewBook.Description)
                .MaximumLength(250).WithMessage("Description must be shorter than 250 characters.");

            RuleFor(x => x.NewBook.Genre)
                .Length(2, 50).WithMessage("Genre must be between 2 and 20 characters.");

        }
    }
}
