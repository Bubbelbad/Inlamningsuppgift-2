using Application.Interfaces.RepositoryInterfaces;
using Domain.Entities.Core;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class AuthorRepository : GenericRepository<Author, Guid>, IAuthorRepository
    {
        private readonly RealDatabase _realDatabase;

        public AuthorRepository(RealDatabase database) : base(database)
        {
            _realDatabase = database;
        }
    }
}
