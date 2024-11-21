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
            var user = _database.Users.FirstOrDefault(user => user.UserName == request.LoginUser.UserName && user.Password == request.LoginUser.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password"); 
            }

            string token = _tokenHelper.GenerateTwtToken(user); 

            return Task.FromResult(token); 
        }
    }
}
