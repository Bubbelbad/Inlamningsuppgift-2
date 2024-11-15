using Domain;
using Domain.Model;

namespace Infrastructure.Database
{
    public class FakeDatabase
    {
        public List<Book> Books { get { return allBooksFromDB; } set { allBooksFromDB = value; } }
        public List<Author> Authors { get { return allAuthorsFromDB; } set { allAuthorsFromDB = value; } }

        private static List<Book> allBooksFromDB = new()
        {
            new(1, "VictorBook1", "Victor", "Beskrivning"),
            new(2, "VictorBook2", "Victor", "Beskrivning"),
            new(3, "VictorBook3", "Victor", "Beskrivning"),
            new(4, "VictorBook4", "Victor", "Beskrivning"),
            new(5, "VictorBook5", "Victor", "Beskrivning"),
        };
        
        private static List<Author> allAuthorsFromDB = new()
        {
            new(1, "Victor", "Ivarson"),
            new(2, "Erik", "Larsson"),
            new(3, "Cecilia", "Al Mouhib"),
            new(4, "Lasse", "Ek"),
            new(5, "Kornelius", "Vanheden"),
        };

        // --- Book CRUD ---

        public async Task<Book> AddNewBook(Book book)
        {
            Books.Add(book);
            return book;
        }

        public async Task<Book> GetBookById(int bookId)
        {
            Book book = Books.FirstOrDefault(b => b.Id == bookId);
            return await Task.FromResult(book);
        }

        public async Task<Book> UpdateBook(Book updatedBook)
        {
            Book bookToUpdate = Books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = updatedBook.Title;
                bookToUpdate.Author = updatedBook.Author;
                bookToUpdate.Description = updatedBook.Description;
            }
            return bookToUpdate;
        }

        public async Task<Book> DeleteBook(int id)
        {
            Book bookToDelete = Books.FirstOrDefault(b => b.Id == id); 
            if (bookToDelete != null) 
            { 
                Books.Remove(bookToDelete); 
            }
            return await Task.FromResult(bookToDelete);
        }


        // --- Author CRUD --- 

        public async Task<Author> AddNewAuthor(Author author)
        {
            Authors.Add(author);
            return author;
        }

        public async Task<Author> GetAuthorById(int authorId)
        {
            Author author = Authors.FirstOrDefault(a => a.Id == authorId);
            return await Task.FromResult(author);
        }

        public async Task<Author> UpdateAuthor(Author updatedAuthor)
        {
            Author authorToUpdate = Authors.FirstOrDefault(a => a.Id == updatedAuthor.Id);
            if (authorToUpdate != null)
            {
                authorToUpdate.FirstName = updatedAuthor.FirstName;
                authorToUpdate.LastName = updatedAuthor.LastName;
            }
            return authorToUpdate;
        }

        public async Task<Author> DeleteAuthor(int id)
        {
            Author authorToDelete = Authors.FirstOrDefault(a => a.Id == id);
            if (authorToDelete != null)
            {
                Authors.Remove(authorToDelete);
            }
            return await Task.FromResult(authorToDelete);
        }
    }
}
