using FluentValidation;

namespace Application.Commands.ReservationCommands.UpdateReservation
{
    public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
    {
        public UpdateReservationCommandValidator()
        {
            RuleFor(x => x.Dto.Id)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.Dto.Status)
                .NotEmpty().WithMessage("Status is required");

            RuleFor(x => x.Dto.CopyId)
                .NotEmpty().WithMessage("CopyId is required");

            RuleFor(x => x.Dto.UserId)
                    .NotEmpty().WithMessage("UserId is required");
        }
    }
}
