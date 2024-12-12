using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using MediatR;


namespace Application.Queries.UserQueries.GetDetailedUserById
{
    internal class GetDetailedUserByIdQueryHandler(IUserRepository repository, IMapper mapper) : IRequestHandler<GetDetailedUserByIdQuery, OperationResult<User>>
    {
        private readonly IUserRepository _userRepository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<User>> Handle(GetDetailedUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null || request.Id == Guid.Empty)
            {
                return OperationResult<User>.Failure("Invalid input");
            }

            try
            {
                var user = await _userRepository.GetUserById(request.Id);
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
