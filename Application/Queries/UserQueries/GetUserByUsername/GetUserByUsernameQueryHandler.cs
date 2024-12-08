
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using MediatR;

namespace Application.Queries.UserQueries.GetUserByUsername
{
    public class GetUserByUsernameQueryHandler(IUserRepository repotisory, IMapper mapper) : IRequestHandler<GetUserByUsernameQuery, OperationResult<User>>
    {
        private readonly IUserRepository _userRepository = repotisory;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<User>> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrEmpty(request.Username))
            {
                return OperationResult<User>.Failure("Invalid input");
            }

            try
            {
                var user = await _userRepository.GetUserByUsername(request.Username);
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
