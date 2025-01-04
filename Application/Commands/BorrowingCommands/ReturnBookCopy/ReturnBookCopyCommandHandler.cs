using Application.Dtos.BorrowingDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using Domain.Entities.Locations;
using Domain.Entities.Transactions;
using MediatR;

namespace Application.Commands.BorrowingCommands.ReturnBookCopy
{
    internal class ReturnBookCopyCommandHandler(IGenericRepository<Borrowing, int> borrowingRepository, IGenericRepository<BookCopy, Guid> bookRepository, IMapper mapper) : IRequestHandler<ReturnBookCopyCommand, OperationResult<GetBorrowingDto>>
    {
        private readonly IGenericRepository<BookCopy, Guid> _bookRepository = bookRepository;
        private readonly IGenericRepository<Borrowing, int> _borrowingRepository = borrowingRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetBorrowingDto>> Handle(ReturnBookCopyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Get the borrowing record
                var borrowing = await _borrowingRepository.GetByIdAsync(request.BorrowId);
                if (borrowing is null)
                {
                    return OperationResult<GetBorrowingDto>.Failure("Borrowing record not found");
                }

                // Get the book copy
                var bookCopy = await _bookRepository.GetByIdAsync(borrowing.CopyId);
                if (bookCopy is null)
                {
                    return OperationResult<GetBorrowingDto>.Failure("Book copy not found");
                }

                // Update the borrowing record
                borrowing.Status = "Returned";
                borrowing.ReturnDate = DateTime.Now;

                var successfulUpdate = await _borrowingRepository.UpdateAsync(borrowing);
                if (successfulUpdate is null)
                {
                    return OperationResult<GetBorrowingDto>.Failure("Operation failed");
                }

                // Update the book copy status
                bookCopy.Status = "Available";
                var successfulBookCopyUpdate = await _bookRepository.UpdateAsync(bookCopy);
                if (successfulBookCopyUpdate is null)
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
