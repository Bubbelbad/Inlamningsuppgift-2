using Application;
using Domain;
using Infrastructure.Database;
using Infrastructure.Repositories;
using System.Threading.Tasks;
using NUnit.Framework; 

namespace TestProject
{
    public class BookServiceTests
    {
        private readonly BookRepository _bookRepository;
        private read

        [SetUp]
        public void SetUp()
        {

        }


        [Test]
        public async Task AddBook_WhenGivenCorrectParams_BookAddedToList()
        {
            FakeDatabase fakeRepository = new FakeDatabase();
            BookService bookService = new BookService(fakeRepository);
            Book bookToTest = new Book(1, "Test", "Victor", "BookService for Testing");

            // Act
            var bookCreated = await bookService.AddBook(bookToTest);

            // Assert
            Assert.That(bookCreated, Is.Not.Null);
            Assert.That(bookCreated.Description, Is.EqualTo(bookToTest.Description));
        }

        [Test]
        public async Task GetBookByBookId_ReturnsBook()
        {
            FakeDatabase fakeDatabase = new FakeDatabase();
            BookService bookService = new BookService(fakeDatabase);
            string expectedtitle = "VictorBook2";

            // Act 
            var result = await bookService.GetBookByBookId(2);

            // Assert
            Assert.That(result.Title, Is.EqualTo(expectedtitle));
        }

        [Test]
        public async Task UpdateBook_ReturnsUpdatedBook()
        {
            FakeDatabase fakeDatabase = new FakeDatabase();
            BookService bookService = new BookService(fakeDatabase);
            Book testBook = await bookService.GetBookByBookId(1);
            Book updatedBook = new Book(1, "AnnanBok", "Vulle", "Description");
            // Act 
            await bookService.UpdateBook(updatedBook);

            // Assert
            var result = await bookService.GetBookByBookId(1);
            Assert.That(result.Title, Is.EqualTo(updatedBook.Title));
        }

        [Test]
        public async Task DeleteBook_ReturnsOk()
        {
            // Arrange
            FakeDatabase fakeDatabase = new FakeDatabase();
            BookService bookService = new BookService(fakeDatabase);

            // Act 
            var result = await bookService.DeleteBook(1);

            // Assert
            Assert.That(result, Is.EqualTo(null));
        }
    }
}