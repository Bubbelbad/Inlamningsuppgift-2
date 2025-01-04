using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using Domain.Entities.Transactions;
using MediatR;

namespace Application.Commands.BorrowingCommands.DeleteBorrowing
{
    internal class DeleteBorrowingCommandHandler(IGenericRepository<Borrowing, int> repository) : IRequestHandler<DeleteBorrowingCommand, OperationResult<bool>>
    {

        public async Task<OperationResult<bool>> Handle(DeleteBorrowingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var successfulDeletion = await repository.DeleteAsync(request.Id);
                if (successfulDeletion is false)
                {
                    return OperationResult<bool>.Failure("Operation failed");
                }
                else
                {
                    return OperationResult<bool>.Success(successfulDeletion);
                }
            }
            catch (Exception e)
            {
                return OperationResult<bool>.Failure(e.Message);
            }
        }
    }
}
