using Domain.Model;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.UserQueries
{
    internal sealed class GetAllUsersQueryHandler(FakeDatabase database) : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly FakeDatabase _database = database;

        public Task<List<User>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {

            if (query == null)
            {
                throw new ArgumentNullException(nameof(query), "Query cannot be null.");
            }

            try
            {
                List<User> allUsersFromFakeDatabase = _database.Users;
                return Task.FromResult(allUsersFromFakeDatabase);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving users from collection.", ex);
            }
        }
    }
}
