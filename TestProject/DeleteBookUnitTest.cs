using Application.Commands.DeleteBook;
using Infrastructure.Database;
using Application.Dtos; 

namespace TestProject
{
    [TestFixture]
    public class DeleteBookUnitTest
    {
        private DeleteBookCommandHandler _handler;
        private FakeDatabase _database;

        [SetUp]
        public void Setup()
        {
            _database = new FakeDatabase();
            _handler = new DeleteBookCommandHandler(_database);
        }

        [Test, Category("DeleteBook")]
        public async Task Handle_WhenGivenValidId_ReturnsFalse()
        {
            // Arrange
            Guid bookId = new Guid("12345678-1234-5678-1234-567812345678");
            var command = new DeleteBookCommand(bookId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test, Category("DeleteBook")]
        public async Task Handle_InvalidBookId_ReturnsFalse()
        {
            // Arrange
            Guid bookId = new Guid("12345678-1234-5678-1234-567812345678");
            var command = new DeleteBookCommand(bookId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}
