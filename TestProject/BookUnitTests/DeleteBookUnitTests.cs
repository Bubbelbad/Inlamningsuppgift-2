using Application.Commands.DeleteBook;
using Infrastructure.Database;

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
        public async Task Handle_ValidInputId_ReturnsTrue()
        {
            // Arrange
            Guid bookId = new Guid("783307e1-ea3b-400b-919d-0c40b2bbae78");
            var command = new DeleteBookCommand(bookId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(true));
        }

        [Test, Category("DeleteBook")]
        public async Task Handle_NonExistingBookId_ReturnsFalse()
        {
            // Arrange
            Guid bookId = new Guid("783307e1-ea3b-400b-919d-0c40b2bbae71");
            var command = new DeleteBookCommand(bookId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
