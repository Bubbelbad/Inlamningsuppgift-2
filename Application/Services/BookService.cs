using Application.Interfaces;
using Domain;
using Infrastructure.Database;
using Infrastructure.Repositories;

namespace Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Book> GetBookByBookId(int bookId)
        {
            Book book = await _bookRepository.GetBookById(bookId);
            return book; 
        }

        public async Task<Book> AddBook(Book book)
        {
            Book addedBook = await _bookRepository.AddNewBook(book);
            return addedBook;
        }


        public async Task<Book> UpdateBook(Book book)
        {
            Book updatedBook = await _bookRepository.UpdateBook(book);
            return updatedBook; 
        }

        public async Task<Book> DeleteBook(int id)
        {
            var result = await _bookRepository.DeleteBook(id);
            return result; 
        }
    }
}