using Domain;

namespace Application.Interfaces
{
    internal interface IBookService
    {
        public Task<Book> AddBook(Book book);
        public Task<Book> GetBookById(Guid id); 
        public Task<Book> UpdateBook(Book book); 
        public Task<Book> DeleteBook(Guid id); 
    }
}
