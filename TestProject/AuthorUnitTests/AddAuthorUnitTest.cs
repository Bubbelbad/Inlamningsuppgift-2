using Application.Commands.AddAuthorCommands.AddAuthor;
using Application.Dtos;
using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using Infrastructure.Database;
using Moq;

namespace TestProject
{
    [TestFixture]
    public class AddAuthorUnitTest
    {
        private AddAuthorCommandHandler _handler;
        private Mock<IAuthorRepository> _mockRepository;

        [SetUp]
        public void SetUp()
        {
            // Initialize the mock repository
            _mockRepository = new Mock<IAuthorRepository>();

            // Set up the mock repository to return a new Author when AddAuthor is called
            _mockRepository.Setup(repo => repo.AddAuthor(It.IsAny<Author>()))
                           .ReturnsAsync((Author author) => author);

            // Initialize the handler with the mock repository
            _handler = new AddAuthorCommandHandler(_mockRepository.Object);
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