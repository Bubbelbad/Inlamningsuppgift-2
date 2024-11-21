using Application.Commands.UpdateBook;
using Application.Dtos;
using Infrastructure.Database;

namespace TestProject
{
    [TestFixture]
    public class UpdateBookUnitTest
    {
        private UpdateBookCommandHandler _handler;
        private FakeDatabase _database;

        [SetUp]
        public void Setup()
        {
            _database = new FakeDatabase();
            _handler = new UpdateBookCommandHandler(_database);
        }


        [Test, Category("UpdateBook")]
        public async Task Handle_ValidInput_ReturnsBook()
        {
            // Arrange
            BookDto bookToTest = new(new Guid("3e2e66cf-5ba6-4cd0-88a1-c37b71cca899"), "Test", "Victor", "BookService for Testing");
            var command = new UpdateBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Description, Is.EqualTo(bookToTest.Description));
        }


        [Test, Category("UpdateBook")]
        public async Task Handle_NullInput_ReturnsNull()
        {
            // Arrange
            BookDto bookToTest = null!; // Use null-forgiving operator to explicitly indicate null
            var command = new UpdateBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }


        [Test, Category("UpdateBook")]
        public async Task Handle_MissingTitle_ReturnsNull()
        {
            // Arrange
            BookDto bookToTest = new(new Guid("12345678-1234-5678-1234-567812345678"), "Test", "Victor", "BookService for Testing"); // Use null-forgiving operator to explicitly indicate null
            var command = new UpdateBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
