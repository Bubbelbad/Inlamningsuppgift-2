using FluentValidation;

namespace Application.Commands.LibraryBranchCommands.DeleteLibraryBranch
{
    public class DeleteLibraryBranchCommandValidator : AbstractValidator<DeleteLibraryBranchCommand>
    {
        public DeleteLibraryBranchCommandValidator()
        {
            RuleFor(x => x.Id)
                .Must(id => id != 0).WithMessage("Id is required, cannot be empty.");
        }
    }
}
