using Domain;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly FakeDatabase _fakeDatabase; 

        public BookRepository(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase; 
        }
        public async Task<Book> GetBookById(int bookId)
        {
            List<Book> allBooks = _fakeDatabase.Books; 

            Book book = _fakeDatabase.Books.FirstOrDefault(b => b.Id == bookId);
            return await Task.FromResult(book); 
        }

        public async Task<Book> AddNewBook(Book book)
        {
            _fakeDatabase.Books.Add(book);
            return book;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            Book bookToUpdate = _fakeDatabase.Books.FirstOrDefault(b => b.Id == book.Id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Author = book.Author;
                bookToUpdate.Description = book.Description;
            }
            return bookToUpdate;
        }

        public async Task<Book> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}
