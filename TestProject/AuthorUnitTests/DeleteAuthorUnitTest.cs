using Application.Commands.AuthorCommands.DeleteAuthor;
using Infrastructure.Database;

namespace TestProject.AuthorUnitTests
{
    [TestFixture]
    public class DeleteAuthorUnitTest
    {
        private FakeDatabase _database;
        private DeleteAuthorCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _database = new FakeDatabase();
            _handler = new DeleteAuthorCommandHandler(_database);
        }
        [Test, Category("DeleteAuthor")]
        public async Task Handle_ValidInputId_ReturnsTrue()
        {
            // Arrange
            Guid authorId = new Guid("d1e16526-228e-4989-af4e-ee9690da3d8a");
            var command = new DeleteAuthorCommand(authorId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(true));
        }

        [Test, Category("DeleteAuthor")]
        public async Task Handle_NonExistingBookId_ReturnsFalse()
        {
            // Arrange
            Guid authorId = new Guid("91e16526-228e-4989-af4e-ee9690da3d8a");
            var command = new DeleteAuthorCommand(authorId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
