using Application.Interfaces.RepositoryInterfaces;
using Domain.Entities.Core;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book, Guid>, IBookRepository
    {
        private readonly RealDatabase _realDatabase;

        public BookRepository(RealDatabase database) : base(database)
        {
            _realDatabase = database;
        }
    }
}
