using Application.Interfaces.RepositoryInterfaces;
using Application.Interfaces.ServiceInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.UserCommands.Register
{
    public class RegisterCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordEncryptionService service) : IRequestHandler<RegisterCommand, OperationResult<User>>
    {
        private readonly IUserRepository _userReposiory = userRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IPasswordEncryptionService _encryptionService = service;

        public async Task<OperationResult<User>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User userToCreate = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = request.NewUser.UserName,
                    PasswordHash = _encryptionService.HashPassword(request.NewUser.Password),
                    Role = "User"
                };

                var createdUser = await _userReposiory.AddUser(userToCreate);
                var mappedUser = _mapper.Map<User>(createdUser);
                return OperationResult<User>.Success(mappedUser);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
