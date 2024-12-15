using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;


namespace Application.Queries.UserQueries.GetDetailedUserById
{
    internal class GetDetailedUserByIdQueryHandler(IUserRepository repository, IMapper mapper) : IRequestHandler<GetDetailedUserByIdQuery, OperationResult<User>>
    {
        private readonly IUserRepository _userRepository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<User>> Handle(GetDetailedUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetDetailedUserById(request.Id);
                var mappedUser = _mapper.Map<User>(user);
                return OperationResult<User>.Success(mappedUser);
            }
            catch
            {
                throw new Exception("User not found");
            }
        }
    }
}
