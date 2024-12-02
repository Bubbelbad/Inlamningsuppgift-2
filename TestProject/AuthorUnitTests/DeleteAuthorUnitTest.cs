using Application.Commands.AuthorCommands.DeleteAuthor;
using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using Infrastructure.Database;
using Moq;

namespace TestProject.AuthorUnitTests
{
    [TestFixture]
    public class DeleteAuthorUnitTest
    {
        private DeleteAuthorCommandHandler _handler;
        private Mock<IAuthorRepository> _mockRepository; 

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IAuthorRepository>();

            // Return true for a valid author ID
            _mockRepository.Setup(repo => repo.DeleteAuthor(It.Is<Guid>(id => id == new Guid("d1e16526-228e-4989-af4e-ee9690da3d8a"))))
                           .ReturnsAsync(true);

            // Return false for a non-existing author ID
            _mockRepository.Setup(repo => repo.DeleteAuthor(It.Is<Guid>(id => id != new Guid("d1e16526-228e-4989-af4e-ee9690da3d8a"))))
                           .ReturnsAsync(false);

            _handler = new DeleteAuthorCommandHandler(_mockRepository.Object);
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
