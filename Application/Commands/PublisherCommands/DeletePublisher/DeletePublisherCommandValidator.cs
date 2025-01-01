using FluentValidation;

namespace Application.Commands.PublisherCommands.DeletePublisher
{
    public class DeletePublisherCommandValidator : AbstractValidator<DeletePublisherCommand>
    {
        public DeletePublisherCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).NotNull().WithMessage("Id must be greater than 0");
        }
    }
}
