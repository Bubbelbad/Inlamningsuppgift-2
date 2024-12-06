using Application.Commands.UpdateBook;
using Application.Dtos;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using Moq;

namespace TestProject
{
    [TestFixture]
    [Category("Book/UnitTests/UpdateBook")]
    public class UpdateBookUnitTest
    {
        private UpdateBookCommandHandler _handler;
        private Mock<IBookRepository> _mockRepository;
        private Mock<IMapper> _mockMapper;

        private static readonly Guid ExampleBookId = Guid.Parse("3e2e66cf-5ba6-4cd0-88a1-c37b71cca899");
        private static readonly Book ExampleBook = new(ExampleBookId, "Test", "Test", "Test");

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IBookRepository>();
            _mockMapper = new Mock<IMapper>();

            _mockRepository.Setup(repo => repo.UpdateBook(It.Is<Book>(obj => obj.Id == ExampleBookId)))
                           .ReturnsAsync(ExampleBook);

            _mockRepository.Setup(repo => repo.GetBookById(It.Is<Guid>(id => id != ExampleBookId)))
                           .ReturnsAsync((Book)null!);

            _mockMapper.Setup(mapper => mapper.Map<Book>(It.IsAny<Book>()))
                       .Returns((Book book) => new Book(ExampleBookId, book.Title, book.Author, book.Description));

            _handler = new UpdateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);
        }


        [Test]
        public async Task Handle_ValidInput_ReturnsBook()
        {
            // Arrange
            BookDto bookToTest = new(new Guid("3e2e66cf-5ba6-4cd0-88a1-c37b71cca899"), "Test", "Test", "Test");
            var command = new UpdateBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.Description, Is.EqualTo(bookToTest.Description));
        }


        [Test]
        public async Task Handle_NullInput_ReturnsNull()
        {
            // Arrange
            BookDto bookToTest = null!; // Use null-forgiving operator to explicitly indicate null
            var command = new UpdateBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result.Data, Is.EqualTo(null));
        }


        [Test]
        public async Task Handle_MissingTitle_ReturnsNull()
        {
            // Arrange
            BookDto bookToTest = new(new Guid("12345678-1234-5678-1234-567812345678"), null!, "Victor", "BookService for Testing"); // Use null-forgiving operator to explicitly indicate null
            var command = new UpdateBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result.Data, Is.EqualTo(null));
        }
    }
}
