using Application.Interfaces;
using Domain;
using Infrastructure.Database;

namespace Application
{
    public class BookService(FakeDatabase database) : IBookService
    {
        private readonly FakeDatabase _database = database; 

        public async Task<Book> GetBookById(int bookId)
        {
            Book book = await _database.GetBookById(bookId);
            return book; 
        }

        public async Task<Book> AddBook(Book book)
        {
            Book addedBook = await _database.AddNewBook(book);
            return addedBook;
        }


        public async Task<Book> UpdateBook(Book book)
        {
            Book updatedBook = await _database.UpdateBook(book);
            return updatedBook; 
        }

        public async Task<Book> DeleteBook(int id)
        {
            var result = await _database.DeleteBook(id);
            return result; 
        }
    }
}