
using Application.Dtos.BorrowingDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Transactions;
using MediatR;

namespace Application.Queries.BorrowingQueries.GetBorrowingById
{
    internal class GetBorrowingByIdQueryHandler(IGenericRepository<Borrowing, int> repository, IMapper mapper) : IRequestHandler<GetBorrowingByIdQuery, OperationResult<GetBorrowingDto>>
    {
        private readonly IGenericRepository<Borrowing, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetBorrowingDto>> Handle(GetBorrowingByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var borrowing = await _repository.GetByIdAsync(request.Id);
                if (borrowing == null)
                {
                    return OperationResult<GetBorrowingDto>.Failure("Borrowing not found");
                }

                var borrowingDto = _mapper.Map<GetBorrowingDto>(borrowing);
                return OperationResult<GetBorrowingDto>.Success(borrowingDto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred.", ex);
            }
        }
    }
}
