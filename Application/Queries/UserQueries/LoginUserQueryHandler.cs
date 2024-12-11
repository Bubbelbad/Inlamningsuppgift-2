using Application.Interfaces.RepositoryInterfaces;
using Application.Interfaces.ServiceInterfaces;
using Application.Queries.UserQueries.Helpers;
using MediatR;

namespace Application.Queries.UserQueries
{
    internal sealed class LoginUserQueryHandler(IUserRepository userRepository, TokenHelper helper, IPasswordEncryptionService service) : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPasswordEncryptionService _encryptionService = service;
        private readonly TokenHelper _tokenHelper = helper;

        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            if (request.password == null || request.Username == null)
            {
                throw new ArgumentNullException(nameof(request), "Request or LoginUser cannot be null.");
            }
            try
            {
                var user = await _userRepository.GetUserByUsername(request.Username);
                if (_encryptionService.VerifyPassword(request.password, user.PasswordHash))
                {
                    string token = _tokenHelper.GenerateTwtToken(user);
                    return token;
                }
                else
                {
                    throw new ApplicationException("Invalid password.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while generating the token.", ex);
            }
        }
    }
}
