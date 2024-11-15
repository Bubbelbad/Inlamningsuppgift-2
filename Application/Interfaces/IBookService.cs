using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    internal interface IBookService
    {
        public Task<Book> AddBook(Book book);
        public Task<Book> GetBookByBookId(int id); 
        public Task<Book> UpdateBook(Book book); 
        public Task<Book> DeleteBook(int id); 
    }
}
