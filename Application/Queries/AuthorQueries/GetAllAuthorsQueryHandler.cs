using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Queries.AuthorQueries
{
    internal class GetAllAuthorsQueryHandler(IMemoryCache memoryCache, IAuthorRepository repository) : IRequestHandler<GetAllAuthorsQuery, List<Author>>
    {
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly IAuthorRepository _authorRepository = repository;
        private const string cacheKey = "allAuthors";

        public async Task<List<Author>> Handle(GetAllAuthorsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                if (!_memoryCache.TryGetValue(cacheKey, out List<Author> allAuthorsFromDatabase))
                {
                    allAuthorsFromDatabase = await _authorRepository.GetAllAuthors();
                    _memoryCache.Set(cacheKey, allAuthorsFromDatabase, TimeSpan.FromMinutes(5));
                }
                return allAuthorsFromDatabase;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving users from collection.", ex);
            }
        }
    }
}
