using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using MediatR;

namespace Application.Queries.UserQueries
{
    internal sealed class GetAllUsersQueryHandler(IUserRepository userRepository) : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<List<User>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {

            if (query == null)
            {
                throw new ArgumentNullException(nameof(query), "Query cannot be null.");
            }
            try
            {
                List<User> allUsersFromFakeDatabase = await _userRepository.GetAllUsers();
                return allUsersFromFakeDatabase;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving users from collection.", ex);
            }
        }
    }
}
