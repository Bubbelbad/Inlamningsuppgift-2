

using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Queries.BookQueries
{
    internal class GetAllBooksQueryHandler(IMemoryCache memoryCache, IBookRepository repository) : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly IBookRepository _bookRepository = repository;
        private const string cacheKey = "allBooks";

        public async Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_memoryCache.TryGetValue(cacheKey, out List<Book> allBooksFromDatabase))
                {
                    allBooksFromDatabase = await _bookRepository.GetAllBooks();
                    _memoryCache.Set(cacheKey, allBooksFromDatabase, TimeSpan.FromMinutes(5));
                }
                return allBooksFromDatabase;
            }
            catch 
            {
                throw new ApplicationException("An error occurred while retrieving users from collection.");
            }
        }  
    }
}
