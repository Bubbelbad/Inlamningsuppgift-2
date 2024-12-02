using Application.Commands.AuthorCommands.UpdateAuthor;
using Application.Commands.UpdateBook;
using Application.Dtos;
using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore.Metadata;
using Moq;

namespace TestProject.AuthorUnitTests
{
    [TestFixture]
    public class UpdateAuthorUnitTest
    {
        private Mock<IAuthorRepository> _mockRepository; 
        private UpdateAuthorCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IAuthorRepository>();

            Guid validAuthorId = new Guid("6ce82e1f-631f-4447-9b3c-8f7137bc0e31");
            Author author = new(validAuthorId, "Test", "Test");

            // Set up the mock repository to handle any Author object with the same Id
            _mockRepository.Setup(repo => repo.UpdateAuthor(It.Is<Author>(obj => obj.Id == validAuthorId)))
                           .ReturnsAsync((Author updatedAuthor) => updatedAuthor);

            _handler = new UpdateAuthorCommandHandler(_mockRepository.Object); 
        }

        [Test, Category("UpdateAuthor")]
        public async Task Handle_ValidInput_ReturnsAuthor()
        {
            // Arrange
            AuthorDto authorToTest = new(new Guid("6ce82e1f-631f-4447-9b3c-8f7137bc0e31"), "Test", "Test");
            var command = new UpdateAuthorCommand(authorToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstName, Is.EqualTo(authorToTest.FirstName));
            Assert.That(result.LastName, Is.EqualTo(authorToTest.LastName));
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
