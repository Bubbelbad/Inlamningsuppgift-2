using Application.Dtos.BorrowingDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;

namespace Application.Queries.BorrowingQueries.GetUserBorrowings
{
    internal class GetUserBorrowingsQueryHandler(IGenericRepository<User, string> repository, IMapper mapper) : IRequestHandler<GetUserBorrowingsQuery, OperationResult<List<GetBorrowingDto>>>
    {
        private readonly IGenericRepository<User, string> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<List<GetBorrowingDto>>> Handle(GetUserBorrowingsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _repository.GetByIdAsync(request.UserId, u => u.Borrowings);
                if (user is null)
                {
                    return OperationResult<List<GetBorrowingDto>>.Failure("User not found found");
                }

                var userBorrowings = user.Borrowings.ToList();
                var mappedUserBorrowings = _mapper.Map<List<GetBorrowingDto>>(user.Borrowings);
                return OperationResult<List<GetBorrowingDto>>.Success(mappedUserBorrowings);
            }
            catch (Exception e)
            {
                return OperationResult<List<GetBorrowingDto>>.Failure(e.Message);
            }
        }
    }
}
