using Domain.Model;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface IBookRepository
    {
        Task<Book> AddBook(Book book);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(Guid id);
        Task<Book> UpdateBook(Book book);
        Task<bool> DeleteBook(Guid id);
    }
}
