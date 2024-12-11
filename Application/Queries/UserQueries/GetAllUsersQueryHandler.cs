using Application.Dtos;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Queries.UserQueries
{
    internal sealed class GetAllUsersQueryHandler(IUserRepository userRepository, IMemoryCache memoryCache, IMapper mapper) : IRequestHandler<GetAllUsersQuery, OperationResult<List<UpdateUserDto>>>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly IMapper _mapper = mapper;
        private const string cacheKey = "allUsers";

        public async Task<OperationResult<List<UpdateUserDto>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
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

                var mappedUsersFromDatabase = _mapper.Map<List<UpdateUserDto>>(allUsersFromDatabase);
                return OperationResult<List<UpdateUserDto>>.Success(mappedUsersFromDatabase);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving users from collection.", ex);
            }
        }
    }
}
