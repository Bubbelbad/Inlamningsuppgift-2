using Application.Dtos.BorrowingDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using Domain.Entities.Locations;
using Domain.Entities.Transactions;
using MediatR;

namespace Application.Commands.BorrowingCommands.BorrowBookCopy
{
    internal class BorrowBookCopyCommandHandler : IRequestHandler<BorrowBookCopyCommand, OperationResult<GetBorrowingDto>>
    {
        private readonly IGenericRepository<Borrowing, int> _borrowingRepository;
        private readonly IGenericRepository<BookCopy, Guid> _bookRepository;
        private readonly IGenericRepository<User, string> _userRepository;
        private readonly IMapper _mapper;
        public BorrowBookCopyCommandHandler(IGenericRepository<Borrowing, int> borrowingRepository, IMapper mapper,
                                          IGenericRepository<BookCopy, Guid> bookRepository, IGenericRepository<User, string> userRepository)
        {
            _borrowingRepository = borrowingRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<GetBorrowingDto>> Handle(BorrowBookCopyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve the book copy
                var bookCopy = await _bookRepository.GetByIdAsync(request.Dto.CopyId);
                if (bookCopy == null || bookCopy.Status != "Available")
                {
                    return OperationResult<GetBorrowingDto>.Failure("Book copy is not available");
                }

                // Retrieve the user
                var user = await _userRepository.GetByIdAsync(request.Dto.UserId.ToString());
                if (user == null)
                {
                    return OperationResult<GetBorrowingDto>.Failure("User not found");
                }

                // Update the bookCopy status
                bookCopy.Status = "Borrowed";
                var succesfulUpdate = await _bookRepository.UpdateAsync(bookCopy);
                if (succesfulUpdate is null)
                {
                    return OperationResult<GetBorrowingDto>.Failure("Operation failed");
                }

                // Create a new borrowing record
                Borrowing borrowing = new()
                {
                    Status = "Active",
                    BorrowDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(14),
                    UserId = request.Dto.UserId.ToString(),
                    CopyId = request.Dto.CopyId,
                    User = user,
                };

                var successfulUpdate = await _bookRepository.UpdateAsync(bookCopy);
                if (successfulUpdate is null)
                {
                    return OperationResult<GetBorrowingDto>.Failure("Operation failed");
                }

                var successfulCreation = await _borrowingRepository.AddAsync(borrowing);
                if (successfulCreation is null)
                {
                    return OperationResult<GetBorrowingDto>.Failure("Operation failed");
                }

                var mappedBorrowing = _mapper.Map<GetBorrowingDto>(successfulCreation);
                return OperationResult<GetBorrowingDto>.Success(mappedBorrowing);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred.", ex);
            }
        }
    }
}
