using Application.Commands.DeleteBook;
using Application.Interfaces.RepositoryInterfaces;
using Infrastructure.Database;
using Moq;

namespace TestProject
{
    [TestFixture]
    public class DeleteBookUnitTest

    {
        private Mock<IBookRepository> _mockRepository; 
        private DeleteBookCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IBookRepository>();

            // Setup mock.DeleteBook returns true when valid ID
            _mockRepository.Setup(repo => repo.DeleteBook(It.Is<Guid>(id => id == new Guid("783307e1-ea3b-400b-919d-0c40b2bbae78"))))
                           .ReturnsAsync(true);

            _mockRepository.Setup(repo => repo.DeleteBook(It.Is<Guid>(id => id != new Guid("783307e1-ea3b-400b-919d-0c40b2bbae78"))))
                           .ReturnsAsync(false); 
                
            _handler = new DeleteBookCommandHandler(_mockRepository.Object);
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
