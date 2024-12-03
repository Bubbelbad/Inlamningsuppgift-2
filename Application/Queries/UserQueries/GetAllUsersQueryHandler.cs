using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Queries.UserQueries
{
    internal sealed class GetAllUsersQueryHandler(IUserRepository userRepository, IMemoryCache memoryCache) : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMemoryCache _memoryCache = memoryCache;
        private const string cacheKey = "allUsers"; 

        public async Task<List<User>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query), "Query cannot be null.");
            }
            try
            {
                if (!_memoryCache.TryGetValue(cacheKey, out List<User> allUsersFromDatabase))
                {
                    allUsersFromDatabase = await _userRepository.GetAllUsers();
                    _memoryCache.Set(cacheKey, allUsersFromDatabase, TimeSpan.FromMinutes(5)); 
                }
                return allUsersFromDatabase;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving users from collection.", ex);
            }
        }
    }
}
