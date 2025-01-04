using Application.Dtos.BorrowingDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Transactions;
using MediatR;

namespace Application.Commands.BorrowingCommands.ReturnBookCopy
{
    internal class ReturnBookCopyCommandHandler(IGenericRepository<Borrowing, int> repository, IMapper mapper) : IRequestHandler<ReturnBookCopyCommand, OperationResult<GetBorrowingDto>>
    {
        private readonly IGenericRepository<Borrowing, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetBorrowingDto>> Handle(ReturnBookCopyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var borrowing = await _repository.GetByIdAsync(request.BorrowId);
                if (borrowing is null)
                {
                    return OperationResult<GetBorrowingDto>.Failure("Borrowing record not found");
                }

                borrowing.Status = "Returned";
                borrowing.ReturnDate = DateTime.Now;

                var successfulUpdate = await _repository.UpdateAsync(borrowing);
                if (successfulUpdate is null)
                {
                    return OperationResult<GetBorrowingDto>.Failure("Operation failed");
                }

                var mappedBorrowing = _mapper.Map<GetBorrowingDto>(successfulUpdate);
                return OperationResult<GetBorrowingDto>.Success(mappedBorrowing);
            }
            catch (Exception e)
            {
                return OperationResult<GetBorrowingDto>.Failure(e.Message);
            }
        }
    }
}
