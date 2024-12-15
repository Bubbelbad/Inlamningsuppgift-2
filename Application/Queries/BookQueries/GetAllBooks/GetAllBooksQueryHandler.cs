using Application.Dtos.BookDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Queries.BookQueries.GetAllBooks
{
    internal class GetAllBooksQueryHandler(IMemoryCache memoryCache, IGenericRepository<Book, Guid> repository, IMapper mapper) : IRequestHandler<GetAllBooksQuery, OperationResult<List<GetBookDto>>>
    {
        private readonly IGenericRepository<Book, Guid> _repository = repository;
        private readonly IMemoryCache _memoryCache = memoryCache;
        private const string cacheKey = "allBooks";
        public readonly IMapper _mapper = mapper;

        public async Task<OperationResult<List<GetBookDto>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_memoryCache.TryGetValue(cacheKey, out List<GetBookDto> mappedBooksFromDatabase))
                {
                    var allBooksFromDatabase = await _repository.GetAllAsync();

                    mappedBooksFromDatabase = _mapper.Map<List<GetBookDto>>(allBooksFromDatabase);

                    _memoryCache.Set(cacheKey, mappedBooksFromDatabase, TimeSpan.FromMinutes(5));
                }

                return OperationResult<List<GetBookDto>>.Success(mappedBooksFromDatabase);
            }
            catch
            {
                throw new ApplicationException("An error occurred while retrieving users from collection.");
            }
        }
    }
}
