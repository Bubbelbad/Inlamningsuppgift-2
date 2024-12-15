using Application.Interfaces.RepositoryInterfaces;
using Domain.Entities.Core;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookRepository(RealDatabase database) : IBookRepository
    {
        private readonly RealDatabase _realDatabase = database;

        public async Task<List<Book>> GetAllBooks()
        {
            List<Book> allBooksFromDatabase = _realDatabase.Books.ToList();
            return allBooksFromDatabase;
        }
    }
}
