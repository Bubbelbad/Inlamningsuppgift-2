
using Application.Dtos.BorrowingDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Transactions;
using MediatR;

namespace Application.Queries.BorrowingQueries.GetAllBorrowings
{
    internal class GetAllBorrowingsQueryHandler(IGenericRepository<Borrowing, int> repository, IMapper mapper) : IRequestHandler<GetAllBorrowingsQuery, OperationResult<List<GetBorrowingDto>>>
    {
        private readonly IGenericRepository<Borrowing, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<List<GetBorrowingDto>>> Handle(GetAllBorrowingsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var borrowings = await _repository.GetAllAsync();
                if (borrowings is null)
                {
                    return OperationResult<List<GetBorrowingDto>>.Failure("No borrowings found");
                }

                var borrowingsDto = _mapper.Map<List<GetBorrowingDto>>(borrowings);
                return OperationResult<List<GetBorrowingDto>>.Success(borrowingsDto);
            }
            catch (Exception e)
            {
                return OperationResult<List<GetBorrowingDto>>.Failure(e.Message);
            }
        }
    }
}
