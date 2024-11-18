using Application;
using Domain;
using Infrastructure.Database;

namespace TestProject
{
    public class BookServiceTests
    {
        [Test]
        public async Task AddBook_WhenGivenCorrectParams_BookAddedToList()
        {
            // Assert
            FakeDatabase fakeDatabase = new(); 
            BookService bookService = new(fakeDatabase);
            Book bookToTest = new(1, "Test", "Victor", "BookService for Testing");

            // Act
            var bookCreated = await bookService.AddBook(bookToTest);

            // Assert
            Assert.That(bookCreated, Is.Not.Null);
            Assert.That(bookCreated.Description, Is.EqualTo(bookToTest.Description));
        }

        [Test]
        public async Task GetBookByBookId_ReturnsBook()
        {
            // Assert
            FakeDatabase fakeDatabase = new();
            BookService bookService = new(fakeDatabase);
            string expectedtitle = "VictorBook2";

            // Act 
            var result = await bookService.GetBookById(2);

            // Assert
            Assert.That(result.Title, Is.EqualTo(expectedtitle));
        }

        [Test]
        public async Task UpdateBook_ReturnsUpdatedBook()
        {
            // Arrange
            var fakeDatabase = new FakeDatabase();
            var bookService = new BookService(fakeDatabase);
            var testBook = await bookService.GetBookById(1);
            var updatedBook = new Book (1, "AnnanBok", "Vulle", "Description");

            // Act 
            await bookService.UpdateBook(updatedBook);

            // Assert
            var result = await bookService.GetBookById(1);
            Assert.That(result.Title, Is.EqualTo(updatedBook.Title));
        }

        [Test]
        public async Task DeleteBook_ReturnsOk()
        {
            // Arrange
            var fakeDatabase = new FakeDatabase();
            var bookService = new BookService(fakeDatabase);

            // Act 
            var result = await bookService.DeleteBook(1);

            // Assert
            Assert.That(result, Is.Not.EqualTo(null));
        }
    }
}