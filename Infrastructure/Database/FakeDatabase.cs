using Domain.Model;

namespace Infrastructure.Database
{
    public class FakeDatabase
    {
        public List<Book> Books { get { return allBooksFromDB; } set { allBooksFromDB = value; } }
        public List<Author> Authors { get { return allAuthorsFromDB; } set { allAuthorsFromDB = value; } }

        private static List<Book> allBooksFromDB = new()
        {
            new(new Guid(), "VictorBook1", "Victor", "Beskrivning"),
            new(new Guid(), "VictorBook2", "Victor", "Beskrivning"),
            new(new Guid(), "VictorBook3", "Victor", "Beskrivning"),
            new(new Guid(), "VictorBook4", "Victor", "Beskrivning"),
            new(new Guid(), "VictorBook5", "Victor", "Beskrivning"),
        };
        
        private static List<Author> allAuthorsFromDB = new()
        {
            new("Victor", "Ivarson"),
            new("Erik", "Larsson"),
            new("Cecilia", "Al Mouhib"),
            new("Lasse", "Ek"),
            new("Kornelius", "Vanheden"),
        };

        // --- Book CRUD ---

        public async Task<Book> AddNewBook(Book book)
        {
            Books.Add(book);
            return book;
        }

        public async Task<Book> GetBookById(Guid bookId)
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
            return await Task.FromResult(bookToUpdate);
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            Book bookToDelete = Books.FirstOrDefault(b => b.Id == id);
            bool actionSuccessful = false;
            if (bookToDelete != null) 
            { 
                Books.Remove(bookToDelete);
                actionSuccessful = true; 
            }
            return await Task.FromResult(actionSuccessful); 
        }


        // --- Author CRUD --- 

        public async Task<Author> AddNewAuthor(Author author)
        {
            Authors.Add(author);
            return author;
        }

        public async Task<Author> GetAuthorById(Guid authorId)
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

        public async Task<Author> DeleteAuthor(Guid id)
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
