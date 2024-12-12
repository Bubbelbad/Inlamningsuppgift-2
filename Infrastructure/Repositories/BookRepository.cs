using Application.Interfaces.RepositoryInterfaces;
using Domain.Entities.Core;
using Infrastructure.Database;

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

        public async Task<Book> GetBookById(Guid id)
        {
            Book book = _realDatabase.Books.FirstOrDefault(book => book.BookId == id);
            return book;
        }

        public async Task<Book> AddBook(Book book)
        {
            _realDatabase.Books.Add(book);
            _realDatabase.SaveChanges();
            return book;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            Book bookToUpdate = _realDatabase.Books.FirstOrDefault(obj => obj.BookId == book.BookId);
            if (bookToUpdate is not null)
            {
                bookToUpdate.Author = book.Author;
                bookToUpdate.Description = book.Description;
                bookToUpdate.Title = book.Title;
                _realDatabase.SaveChanges();
            }
            return bookToUpdate;
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            bool actionSuccessful = false;
            Book bookToDelete = _realDatabase.Books.FirstOrDefault(obj => obj.BookId == id);
            if (bookToDelete is not null)
            {
                _realDatabase.Books.Remove(bookToDelete);
                _realDatabase.SaveChanges();
                actionSuccessful = true;
            }
            return actionSuccessful;
        }
    }
}
