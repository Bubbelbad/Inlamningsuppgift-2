using Application;
using Application.Commands.AddAuthorCommands.AddAuthor;
using Application.Dtos;
using Application.Queries.AuthorQueries;
using Domain.Model;
using Infrastructure.Database;

namespace TestProject
{
    [TestFixture]
    public class AddAuthorUnitTest
    {
        private AddAuthorCommandHandler _handler;
        private FakeDatabase _database;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _database = new FakeDatabase();
            _handler = new AddAuthorCommandHandler(_database);
        }

        [Test, Category("AddAuthor")]
        public async Task Handle_ValidBookParam_ReturnsCorrectBook()
        {
            // Arrange
            AddAuthorDto authorToTest = new ("Henrik", "Testsson");
            var command = new AddAuthorCommand(authorToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstName, Is.EqualTo(authorToTest.FirstName));
        }

        [Test, Category("AddAuthor")]
        public async Task Handle_InvalidValiId_ReturnsNull()
        {
            // Arrange
            AddAuthorDto bookToTest = new("Test", "Testsson");
            var command = new AddAuthorCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}