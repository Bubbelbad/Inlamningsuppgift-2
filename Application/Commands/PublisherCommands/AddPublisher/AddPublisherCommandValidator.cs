using FluentValidation;

namespace Application.Commands.PublisherCommands.AddPublisher
{
    public class AddPublisherCommandValidator : AbstractValidator<AddPublisherCommand>
    {
        public AddPublisherCommandValidator()
        {
            RuleFor(x => x.Dto.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters");

            RuleFor(x => x.Dto.Address)
                .NotEmpty().WithMessage("Address is required");

            RuleFor(x => x.Dto.ContactInfo)
                .NotEmpty().WithMessage("Contact info is required");
        }
    }
}
