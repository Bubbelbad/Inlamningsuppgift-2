using Application.Commands.AddBook;
using Application.Dtos;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using Moq;

namespace TestProject
{
    [TestFixture]
    [Category("Book/UnitTests/AddBook")]
    public class AddBookUnitTest
    {
        private AddBookCommandHandler _handler;
        private Mock<IBookRepository> _mockRepository;
        private Mock<IMapper> _mockMapper; 

        private static readonly Guid ExampleBookId = Guid.Parse("12345678-1234-1234-1234-1234567890ab");
        private static readonly AddBookDto ExampleBookDto = new("Test", "Testsson", "An example book for Testing");

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockRepository = new Mock<IBookRepository>();
            _mockMapper = new Mock<IMapper>();

            //Set up mock to return a new Book when AddBook is called
            _mockRepository.Setup(repo => repo.AddBook(It.IsAny<Book>()))
                .ReturnsAsync((Book book) => book);

            _mockMapper.Setup(mapper => mapper.Map<Book>(It.IsAny<Book>()))
                .Returns((Book book) => new Book(ExampleBookId, book.Title, book.Author, book.Description)); 

            _handler = new AddBookCommandHandler(_mockRepository.Object, _mockMapper.Object);
        }

        [Test]
        public async Task Handle_ValidInput_ReturnsBook()
        {
            // Arrange
            var command = new AddBookCommand(ExampleBookDto);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.Description, Is.EqualTo(ExampleBookDto.Description));
        }

        [Test]
        public async Task Handle_NullInput_ReturnsNull()
        {
            // Arrange
            AddBookDto bookToTest = null!; // Use null-forgiving operator to explicitly indicate null
            var command = new AddBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.EqualTo(false));
        }

        [Test]
        public async Task Handle_MissingTitle_ReturnsNull()
        {
            // Arrange
            AddBookDto bookToTest = new(null!, "Test Testsson", "An example book for Testing"); // Use null-forgiving operator to explicitly indicate null
            var command = new AddBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.EqualTo(false));
        }
    }
}
