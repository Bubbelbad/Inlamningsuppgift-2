using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Queries.AuthorQueries
{
    internal class GetAllAuthorsQueryHandler(IMemoryCache memoryCache, IAuthorRepository repository, IMapper mapper) : IRequestHandler<GetAllAuthorsQuery, OperationResult<List<Author>>>
    {
        public IMapper _mapper = mapper; 
        private readonly IAuthorRepository _authorRepository = repository;
        private readonly IMemoryCache _memoryCache = memoryCache;
        private const string cacheKey = "allAuthors";

        public async Task<OperationResult<List<Author>>> Handle(GetAllAuthorsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                if (!_memoryCache.TryGetValue(cacheKey, out List<Author> mappedAuthorsFromDatabase))
                {
                    var allAuthorsFromDatabase = await _authorRepository.GetAllAuthors();

                    mappedAuthorsFromDatabase = _mapper.Map<List<Author>>(allAuthorsFromDatabase); 

                    _memoryCache.Set(cacheKey, allAuthorsFromDatabase, TimeSpan.FromMinutes(5));
                }

                return OperationResult<List<Author>>.Success(mappedAuthorsFromDatabase);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving users from collection.", ex);
            }
        }
    }
}
