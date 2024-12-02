using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class BookRepository(RealDatabase database) : IBookRepository
    {
        private readonly RealDatabase _realDatabase = database;

        public async Task<Book> AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
