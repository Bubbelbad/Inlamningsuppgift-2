using Application.Commands.AddAuthorCommands.AddAuthor;
using Application.Dtos;
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
        public async Task Handle_ValidInput_ReturnsCorrectAuthor()
        {
            // Arrange
            AddAuthorDto authorToTest = new("Test", "Testsson");
            var command = new AddAuthorCommand(authorToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstName, Is.EqualTo(authorToTest.FirstName));
        }

        [Test, Category("AddAuthor")]
        public async Task Handle_NullInput_ReturnsNull()
        {
            // Arrange
            AddAuthorDto authorToTest = null!; // Use null-forgiving operator to explicitly indicate null
            var command = new AddAuthorCommand(authorToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test, Category("AddAuthor")]
        public async Task Handle_MissingFirstName_ReturnsNull()
        {
            // Arrange
            AddAuthorDto authorToTest = new(null!, "Testsson"); // Use null-forgiving operator to explicitly indicate null
            var command = new AddAuthorCommand(authorToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}