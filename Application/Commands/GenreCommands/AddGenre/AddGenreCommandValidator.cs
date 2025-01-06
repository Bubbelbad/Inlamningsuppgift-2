
using FluentValidation;

namespace Application.Commands.GenreCommands.AddGenre
{
    public class AddGenreCommandValidator : AbstractValidator<AddGenreCommand>
    {
        public AddGenreCommandValidator()
        {
            RuleFor(x => x.Dto.Name)
                .NotEmpty().MaximumLength(50).WithMessage("Name is required");

            RuleFor(x => x.Dto.Description)
                .NotEmpty().MaximumLength(250).WithMessage("Description is required");
        }
    }
}
