using Application.Commands.AddBook;
using Application.Dtos;
using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
using Infrastructure.Database;
using Moq;

namespace TestProject
{
    [TestFixture]
    public class AddBookUnitTest
    {
        private AddBookCommandHandler _handler;
        private Mock<IBookRepository> _mockRepository; 

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockRepository = new Mock<IBookRepository>();

            //Set up mock to return a new Book when AddBook is called
            _mockRepository.Setup(repo => repo.AddBook(It.IsAny<Book>()))
                .ReturnsAsync((Book book) => book); 

            _handler = new AddBookCommandHandler(_mockRepository.Object);
        }

        [Test, Category("AddBook")]
        public async Task Handle_ValidInput_ReturnsBook()
        {
            // Arrange
            AddBookDto bookToTest = new("Book of Test", "Test Testsson", "An example book for Testing");
            var command = new AddBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Description, Is.EqualTo(bookToTest.Description));
        }

        [Test, Category("AddBook")]
        public async Task Handle_NullInput_ReturnsNull()
        {
            // Arrange
            AddBookDto bookToTest = null!; // Use null-forgiving operator to explicitly indicate null
            var command = new AddBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test, Category("AddBook")]
        public async Task Handle_MissingTitle_ReturnsNull()
        {
            // Arrange
            AddBookDto bookToTest = new(null!, "Test Testsson", "An example book for Testing"); // Use null-forgiving operator to explicitly indicate null
            var command = new AddBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
