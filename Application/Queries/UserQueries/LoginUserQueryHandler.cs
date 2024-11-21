using Application.Queries.UserQueries.Helpers;
using Infrastructure.Database;
using MediatR;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Queries.UserQueries
{
    internal sealed class LoginUserQueryHandler(FakeDatabase database, TokenHelper helper) : IRequestHandler<LoginUserQuery, string>
    {
        private readonly FakeDatabase _database = database;
        private readonly TokenHelper _tokenHelper = helper; 

        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            if (request == null || request.LoginUser == null)
            {
                throw new ArgumentNullException(nameof(request), "Request or LoginUser cannot be null.");
            }

            var user = _database.Users.FirstOrDefault(user => user.UserName == request.LoginUser.UserName && user.Password == request.LoginUser.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password"); 
            }
            try
            {
                string token = _tokenHelper.GenerateTwtToken(user); 
                return Task.FromResult(token); 
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while generating the token.", ex);
            }
        }
    }
}
