using Application.Commands.UpdateBook;
using Application.Dtos;
using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using Moq;

namespace TestProject
{
    [TestFixture]
    public class UpdateBookUnitTest
    {
        private Mock<IBookRepository> _mockRepository; 
        private UpdateBookCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IBookRepository>();

            Guid validBookId = new Guid("3e2e66cf-5ba6-4cd0-88a1-c37b71cca899");
            var book = new Book(validBookId, "Test", "Test", "Test");
            
            _mockRepository.Setup(repo => repo.UpdateBook(It.Is<Book>(obj => obj.Id == validBookId)))
                           .ReturnsAsync(book);

            _mockRepository.Setup(repo => repo.GetBookById(It.Is<Guid>(id => id != validBookId)))
                           .ReturnsAsync((Book)null);

            _handler = new UpdateBookCommandHandler(_mockRepository.Object);
        }


        [Test, Category("UpdateBook")]
        public async Task Handle_ValidInput_ReturnsBook()
        {
            // Arrange
            BookDto bookToTest = new(new Guid("3e2e66cf-5ba6-4cd0-88a1-c37b71cca899"), "Test", "Test", "Test");
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
