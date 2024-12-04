using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Queries.BookQueries
{
    internal class GetAllBooksQueryHandler(IMemoryCache memoryCache, IBookRepository repository, IMapper mapper) : IRequestHandler<GetAllBooksQuery, OperationResult<List<Book>>>
    {
        private readonly IBookRepository _bookRepository = repository;
        private readonly IMemoryCache _memoryCache = memoryCache;
        private const string cacheKey = "allBooks";
        public IMapper _mapper = mapper; 

        public async Task<OperationResult<List<Book>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_memoryCache.TryGetValue(cacheKey, out List<Book> mappedBooksFromDatabase))
                {
                    var allBooksFromDatabase = await _bookRepository.GetAllBooks();
                    mappedBooksFromDatabase = _mapper.Map<List<Book>>(allBooksFromDatabase); 

                    _memoryCache.Set(cacheKey, mappedBooksFromDatabase, TimeSpan.FromMinutes(5));
                }
                return OperationResult<List<Book>>.Success(mappedBooksFromDatabase);
            }
            catch 
            {
                throw new ApplicationException("An error occurred while retrieving users from collection.");
            }
        }  
    }
}
