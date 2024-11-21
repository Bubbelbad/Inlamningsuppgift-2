using Domain.Model;

namespace Infrastructure.Database
{
    public class FakeDatabase
    {
        public List<Book> Books { get { return allBooksFromDB; } set { allBooksFromDB = value; } }
        public List<Author> Authors { get { return allAuthorsFromDB; } set { allAuthorsFromDB = value; } }


        //LÄGG TILL LISTA FÖR AUTHORS I BOOK
        private static List<Book> allBooksFromDB = new()
        {
            new(new Guid("2bfaf5e9-d978-464c-b778-7567ef2dde29"), "VictorBook1", "Victor", "Beskrivning"),
            new(new Guid("3e2e66cf-5ba6-4cd0-88a1-c37b71cca899"), "VictorBook2", "Victor", "Beskrivning"),
            new(new Guid("6896990f-a8ac-42d6-946e-c75a49b4c549"), "VictorBook3", "Victor", "Beskrivning"),
            new(new Guid("d03ed6bd-63f8-4b19-a9e4-00b1da267186"), "VictorBook4", "Victor", "Beskrivning"),
            new(new Guid("783307e1-ea3b-400b-919d-0c40b2bbae78"), "VictorBook5", "Victor", "Beskrivning"),
        };

        private static List<Author> allAuthorsFromDB = new()
        {
            new Author(new Guid("1051869e-47b8-4c7e-b2b4-799fb441d092"), "Victor", "Ivarson"),
            new Author(new Guid("d1e16526-228e-4989-af4e-ee9690da3d8a"), "Erik", "Larsson"),
            new Author(new Guid("6ce82e1f-631f-4447-9b3c-8f7137bc0e31"), "Cecilia", "Al Mouhib"),
            new Author(new Guid("04c1a20b-ec2f-4eda-bf3b-4fa165529240"), "Lasse", "Ek"),
            new Author(new Guid("fc22325e-0fa3-4615-aa6c-c7fe459a2735"), "Kornelius", "Vanheden"),
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

        public async Task<bool> DeleteAuthor(Guid id)
        {
            Author authorToDelete = Authors.FirstOrDefault(a => a.Id == id);
            bool actionSuccessful = false;
            if (authorToDelete != null)
            {
                Authors.Remove(authorToDelete);
                actionSuccessful = true;
            }
            return await Task.FromResult(actionSuccessful);
        }
    }
}
