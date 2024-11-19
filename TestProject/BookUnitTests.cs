using Application;
using Application.Commands.AddBook;
using Application.Dtos;
using Domain.Model;
using Infrastructure.Database;

namespace TestProject
{
    [TestFixture]
    public class BookServiceTests
    {
        private AddBookCommandHandler _handler;
        private FakeDatabase _database;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _database = new FakeDatabase();
            _handler = new AddBookCommandHandler(_database);
        }

        [Test]
        public async Task AddBook_WhenGivenCorrectParams_BookAddedToList()
        {
            // Arrange
            BookDto bookToTest = new(new Guid(), "Test", "Victor", "BookService for Testing");
            var command = new AddBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None); 

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Description, Is.EqualTo(bookToTest.Description));
        }

        //[Test]
        //public async Task GetBookByBookId_ReturnsBook()
        //{
        //    // Assert
        //    FakeDatabase fakeDatabase = new();
        //    BookService bookService = new(fakeDatabase);
        //    string expectedtitle = "VictorBook2";

        //    // Act 
        //    var result = await bookService.GetBookById(new Guid());

        //    // Assert
        //    Assert.That(result.Title, Is.EqualTo(expectedtitle));
        //}

        //[Test]
        //public async Task UpdateBook_ReturnsUpdatedBook()
        //{
        //    // Arrange
        //    var fakeDatabase = new FakeDatabase();
        //    var bookService = new BookService(fakeDatabase);
        //    var testBook = await bookService.GetBookById(new Guid());
        //    var updatedBook = new Book ("AnnanBok", "Vulle", "Description");

        //    // Act 
        //    await bookService.UpdateBook(updatedBook);

        //    // Assert
        //    var result = await bookService.GetBookById(new Guid());
        //    Assert.That(result.Title, Is.EqualTo(updatedBook.Title));
        //}

        //[Test]
        //public async Task DeleteBook_ReturnsOk()
        //{
        //    // Arrange
        //    var fakeDatabase = new FakeDatabase();
        //    var bookService = new BookService(fakeDatabase);

        //    // Act 
        //    var result = await bookService.DeleteBook(new Guid());

        //    // Assert
        //    Assert.That(result, Is.Not.EqualTo(null));
        //}
    }
}