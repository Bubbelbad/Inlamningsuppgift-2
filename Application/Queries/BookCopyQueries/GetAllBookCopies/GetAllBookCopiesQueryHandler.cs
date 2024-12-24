
using Application.Dtos.BookCopyDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Locations;
using MediatR;

namespace Application.Queries.BookCopyQueries.GetAllBookCopies
{
    internal class GetAllBookCopiesQueryHandler(IGenericRepository<BookCopy, Guid> repository, IMapper mapper) : IRequestHandler<GetAllBookCopiesQuery, OperationResult<List<GetBookCopyDto>>>
    {
        private readonly IGenericRepository<BookCopy, Guid> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<List<GetBookCopyDto>>> Handle(GetAllBookCopiesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allBookCopies = await _repository.GetAllAsync();
                var mappedBookCopies = _mapper.Map<List<GetBookCopyDto>>(allBookCopies);
                return OperationResult<List<GetBookCopyDto>>.Success(mappedBookCopies);
            }
            catch (Exception ex)
            {
                throw new Exception("Nope", ex);
            }
        }
    }
}
