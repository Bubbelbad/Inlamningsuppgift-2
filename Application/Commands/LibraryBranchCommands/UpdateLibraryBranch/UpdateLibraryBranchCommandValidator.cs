using FluentValidation;

namespace Application.Commands.LibraryBranchCommands.UpdateLibraryBranch
{
    public class UpdateLibraryBranchCommandValidator : AbstractValidator<UpdateLibraryBranchCommand>
    {
        public UpdateLibraryBranchCommandValidator()
        {
            RuleFor(x => x.dto.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(30).WithMessage("Name cannot be longer than 30 characters.");

            RuleFor(x => x.dto.Location)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(50).WithMessage("Address cannot be longer than 50 characters.");

            RuleFor(x => x.dto.ContactInfo)
                .NotEmpty().WithMessage("Contact info is required.")
                .MaximumLength(15).WithMessage("Contact cannot be longer than 50 characters.");
        }
    }
}
