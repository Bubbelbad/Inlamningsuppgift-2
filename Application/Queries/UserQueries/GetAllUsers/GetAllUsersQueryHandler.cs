using Application.Dtos.BookDtos;
using Application.Dtos.UserDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Queries.UserQueries.GetAllUsers
{
    internal sealed class GetAllUsersQueryHandler(IGenericRepository<User, string> repository, IMemoryCache memoryCache, IMapper mapper) : IRequestHandler<GetAllUsersQuery, OperationResult<List<GetUserDto>>>
    {
        private readonly IGenericRepository<User, string> _repository = repository;
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly IMapper _mapper = mapper;
        private const string cacheKey = "allUsers";

        public async Task<OperationResult<List<GetUserDto>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query), "Query cannot be null.");
            }
            try
            {


                if (!_memoryCache.TryGetValue(cacheKey, out List<GetUserDto> mappedUsersFromDatabase))
                {
                    var allUsersFromDatabase = await _repository.GetAllAsync();
                    mappedUsersFromDatabase = _mapper.Map<List<GetUserDto>>(allUsersFromDatabase);
                    // _memoryCache.Set(cacheKey, allUsersFromDatabase, TimeSpan.FromMinutes(5));
                }

                return OperationResult<List<GetUserDto>>.Success(mappedUsersFromDatabase);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving users from collection.", ex);
            }
        }
    }
}
