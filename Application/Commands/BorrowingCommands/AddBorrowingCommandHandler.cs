using Application.Dtos.BorrowingDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Transactions;
using MediatR;

namespace Application.Commands.BorrowingCommands
{
    internal class AddBorrowingCommandHandler(IGenericRepository<Borrowing, int> repository, IMapper mapper) : IRequestHandler<AddBorrowingCommand, OperationResult<GetBorrowingDto>>
    {
        private readonly IGenericRepository<Borrowing, int> _repository = repository;
        public IMapper _mapper = mapper;

        public async Task<OperationResult<GetBorrowingDto>> Handle(AddBorrowingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Borrowing borrowing = new()
                {
                    Status = "Borrowed",
                    BorrowDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(14),
                    UserId = request.Dto.UserId.ToString(),
                    CopyId = request.Dto.CopyId
                };

                var successfulCreation = await _repository.AddAsync(borrowing);
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
