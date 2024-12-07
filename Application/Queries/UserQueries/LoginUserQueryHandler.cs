using Application.Interfaces.RepositoryInterfaces;
using Application.Queries.UserQueries.Helpers;
using MediatR;

namespace Application.Queries.UserQueries
{
    internal sealed class LoginUserQueryHandler(IUserRepository userRepository, TokenHelper helper) : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly TokenHelper _tokenHelper = helper;

        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            if (request == null || request.LoginUser == null)
            {
                throw new ArgumentNullException(nameof(request), "Request or LoginUser cannot be null.");
            }
            //Implement logic here:
            var user = await _userRepository.LogInUser(request.LoginUser.UserName, request.LoginUser.Password);
            //var user = _database.Users.FirstOrDefault(user => user.UserName == request.LoginUser.UserName && user.Password == request.LoginUser.Password);

            if (user is null)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }
            try
            {
                string token = _tokenHelper.GenerateTwtToken(user);
                return token;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while generating the token.", ex);
            }
        }
    }
}
