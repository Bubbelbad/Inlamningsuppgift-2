using Application.Dtos.BookDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Queries.BookQueries.GetAllBooks
{
    internal class GetAllBooksQueryHandler(IMemoryCache memoryCache, IBookRepository repository, IMapper mapper) : IRequestHandler<GetAllBooksQuery, OperationResult<List<GetBookDto>>>
    {
        private readonly IBookRepository _bookRepository = repository;
        private readonly IMemoryCache _memoryCache = memoryCache;
        private const string cacheKey = "allBooks";
        public IMapper _mapper = mapper;

        public async Task<OperationResult<List<GetBookDto>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_memoryCache.TryGetValue(cacheKey, out List<Book> allBooksFromDatabase))
                {
                    allBooksFromDatabase = await _bookRepository.GetAllBooks();
                    _memoryCache.Set(cacheKey, allBooksFromDatabase, TimeSpan.FromMinutes(5));
                }

                var mappedBooksFromDatabase = _mapper.Map<List<GetBookDto>>(allBooksFromDatabase);
                return OperationResult<List<GetBookDto>>.Success(mappedBooksFromDatabase);
            }
            catch
            {
                throw new ApplicationException("An error occurred while retrieving users from collection.");
            }
        }
    }
}
