using Application.Interfaces.RepositoryInterfaces;
using Application.Interfaces.ServiceInterfaces;
using Application.Queries.UserQueries.Helpers;
using MediatR;

namespace Application.Commands.UserCommands.LoginUser
{
    internal sealed class LoginUserCommandHandler(IUserRepository userRepository, TokenHelper helper, IPasswordEncryptionService service) : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPasswordEncryptionService _encryptionService = service;
        private readonly TokenHelper _tokenHelper = helper;

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            if (request.UserDto.Password == null || request.UserDto.UserName == null)
            {
                throw new ArgumentNullException(nameof(request), "Request or LoginUser cannot be null.");
            }
            try
            {
                var user = await _userRepository.GetUserByUsername(request.UserDto.UserName);
                if (_encryptionService.VerifyPassword(request.UserDto.Password, user.PasswordHash))
                {
                    string token = _tokenHelper.GenerateTwtToken(user);
                    return token;
                }
                else
                {
                    throw new ApplicationException("Invalid Password.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while generating the token.", ex);
            }
        }
    }
}
