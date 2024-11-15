using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IBookRepository
    {
        public Task<Book> GetBookById(int bookId);
        public Task<Book> AddNewBook(Book book);
        public Task<Book> UpdateBook(Book book);
        public Task<Book> DeleteBook(int id);
    }
}
