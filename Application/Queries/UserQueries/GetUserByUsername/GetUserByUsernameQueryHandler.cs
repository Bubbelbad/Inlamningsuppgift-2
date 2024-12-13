using Application.Dtos.UserDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Queries.UserQueries.GetUserByUsername
{
    public class GetUserByUsernameQueryHandler(IUserRepository repotisory, IMapper mapper) : IRequestHandler<GetUserByUsernameQuery, OperationResult<GetUserByUserNameDto>>
    {
        private readonly IUserRepository _userRepository = repotisory;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetUserByUserNameDto>> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrEmpty(request.Username))
            {
                return OperationResult<GetUserByUserNameDto>.Failure("Invalid input");
            }

            try
            {
                var user = await _userRepository.GetUserByUsername(request.Username);
                var mappedUser = _mapper.Map<GetUserByUserNameDto>(user);
                return OperationResult<GetUserByUserNameDto>.Success(mappedUser);
            }
            catch
            {
                throw new Exception("User not found");
            }
        }
    }
}
