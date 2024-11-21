using Application;
using Application.Commands.AddBook;
using Application.Dtos;
using Application.Queries.BookQueries;
using Domain.Model;
using Infrastructure.Database;

namespace TestProject
{
    [TestFixture]
    public class AddBookUnitTest
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

        [Test, Category("AddBook")]
        public async Task Handle_ValidBookParam_ReturnsCorrectBook()
        {
            // Arrange
            AddBookDto bookToTest = new("Book of Test", "Test Testsson", "An example book for Testing");
            var command = new AddBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Description, Is.EqualTo(bookToTest.Description));
        }

        [Test, Category("AddBook")]
        public async Task Handle_InvalidValiId_ReturnsNull()
        {
            // Arrange
            AddBookDto bookToTest = new("Book of Test", "Test Testsson", "An example book for Testing");
            var command = new AddBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
