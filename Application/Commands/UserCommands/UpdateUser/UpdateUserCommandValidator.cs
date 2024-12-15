using FluentValidation;

namespace Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.UserToUpdate.Id)
                .NotEmpty().WithMessage("UserId is required")
                .NotNull().WithMessage("UserId is required");

            RuleFor(x => x.UserToUpdate.UserName)
                .NotEmpty().WithMessage("Username is required")
                .NotNull().WithMessage("Username is required");

            RuleFor(x => x.UserToUpdate.Password)
                .NotEmpty().WithMessage("Password is required")
                .NotNull().WithMessage("Password is required");
        }
    }
}
