
using FluentValidation;

namespace Application.Commands.ReservationCommands.AddReservation
{
    public class AddReservationCommandValidator : AbstractValidator<AddReservationCommand>
    {
        public AddReservationCommandValidator()
        {
            RuleFor(x => x.Dto.UserId)
                .NotEmpty().WithMessage("UserId required")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters");

            RuleFor(x => x.Dto.CopyId)
                .NotEmpty().WithMessage("CopyId is required");
        }
    }
}
