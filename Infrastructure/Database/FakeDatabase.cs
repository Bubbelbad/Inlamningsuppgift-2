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
            new Book(1, "VictorBook1", "Victor", "Beskrivning"),
            new Book(2, "VictorBook2", "Victor", "Beskrivning"),
            new Book(3, "VictorBook3", "Victor", "Beskrivning"),
            new Book(4, "VictorBook4", "Victor", "Beskrivning"),
            new Book(5, "VictorBook5", "Victor", "Beskrivning"),
        };

        private static List<Author> allAuthorsFromDB = new()
        {
            new Author(1, "Victor", "Ivarson"),
            new Author(2, "VictorBook2", "Victor"),
            new Author(3, "VictorBook3", "Victor"),
            new Author(4, "VictorBook4", "Victor"),
            new Author(5, "VictorBook5", "Victor"),
        };
    }
}
