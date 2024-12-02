using Application.Commands.AuthorCommands.UpdateAuthor;
using Application.Commands.UpdateBook;
using Application.Dtos;
using Application.Interfaces.RepositoryInterfaces;
using Infrastructure.Database;

namespace TestProject.AuthorUnitTests
{
    [TestFixture]
    public class UpdateAuthorUnitTest
    {
        private IAuthorRepository _repository; 
        private UpdateAuthorCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _handler = new UpdateAuthorCommandHandler(_repository); 
        }

        [Test, Category("UpdateAuthor")]
        public async Task Handle_ValidInput_ReturnsAuthor()
        {
            // Arrange
            AuthorDto authorToTest = new(new Guid("6ce82e1f-631f-4447-9b3c-8f7137bc0e31"), "Testarn", "Victorsson");
            var command = new UpdateAuthorCommand(authorToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstName, Is.EqualTo(authorToTest.FirstName));
        }


        [Test, Category("UpdateAuthor")]
        public async Task Handle_NullInput_ReturnsNull()
        {
            // Arrange
            AuthorDto authorToTest = null!; // Use null-forgiving operator to explicitly indicate null
            var command = new UpdateAuthorCommand(authorToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }


        [Test, Category("UpdateAuthor")]
        public async Task Handle_MissingFirstName_ReturnsNull()
        {
            // Arrange
            AuthorDto bookToTest = new(new Guid("12345678-1234-5678-1234-567812345678"), "Test", "Victorsson"); // Use null-forgiving operator to explicitly indicate null
            var command = new UpdateAuthorCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
