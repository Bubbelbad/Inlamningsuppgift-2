
using FluentValidation;

namespace Application.Commands.UserCommands.LoginUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.UserDto.UserName)
                .NotEmpty().WithMessage("Username is required")
                .NotNull().WithMessage("Username is required");

            RuleFor(x => x.UserDto.Password)
                .NotEmpty().WithMessage("Password is required")
                .NotNull().WithMessage("Password is required");
        }
    }
}
