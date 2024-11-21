using Domain.Model;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.UserQueries
{
    internal sealed class GetAllUsersQueryHandler(FakeDatabase database) : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly FakeDatabase _database = database;

        public Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> allUsersFromFakeDatabase = _database.Users;
            return Task.FromResult(allUsersFromFakeDatabase); 
        }
    }
}
