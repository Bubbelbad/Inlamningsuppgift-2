
using FluentValidation;

namespace Application.Commands.PublisherCommands.UpdatePublisher
{
    public class UpdatePublisherCommandValidator : AbstractValidator<UpdatePublisherCommand>
    {
        public UpdatePublisherCommandValidator()
        {
            RuleFor(x => x.Dto.PublisherId)
                .GreaterThan(0).NotNull().WithMessage("Id must be greater than 0");

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
