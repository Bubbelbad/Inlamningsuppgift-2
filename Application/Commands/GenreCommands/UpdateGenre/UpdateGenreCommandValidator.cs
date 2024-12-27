
using FluentValidation;

namespace Application.Commands.GenreCommands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.Dto.Id)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.Dto.Description)
                .NotEmpty().MaximumLength(250).WithMessage("Description is required");

            RuleFor(x => x.Dto.Name)
                .NotEmpty().MaximumLength(50).WithMessage("Name is required");
        }
    }
}
