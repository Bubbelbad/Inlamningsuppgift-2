using FluentValidation;

namespace Application.Commands.ReservationCommands.DeleteReservation
{
    public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
    {
        public DeleteReservationCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id can not be empty");
        }
    }
}
