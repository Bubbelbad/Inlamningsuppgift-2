using Application.Commands.BookCommands.AddBook;
using Application.Dtos.BookDtos;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Entities.Core;
using Moq;

namespace TestProject.BookUnitTests
{
    [TestFixture]
    [Category("Book/UnitTests/AddBook")]
    public class AddBookUnitTest
    {
        private AddBookCommandHandler _handler;
        private Mock<IGenericRepository<Book, Guid>> _mockRepository;
        private Mock<IMapper> _mockMapper;

        private static readonly Guid ExampleBookId = Guid.Parse("12345678-1234-1234-1234-1234567890ab");
        private static readonly AddBookDto ExampleBookDto = new()
        {
            Title = "Test",
            Genre = "Fantasy",
            Description = "An example book for Testing",
            AuthorId = Guid.Parse("12345678-1234-1234-1234-1234567890ab")
        };

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockRepository = new Mock<IGenericRepository<Book, Guid>>();
            _mockMapper = new Mock<IMapper>();

            // Set up mock to return a new Book when AddBook is called
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Book>()))
                .ReturnsAsync((Book book) => book);

            // Set up mock to map from AddBookDto to Book
            _mockMapper.Setup(mapper => mapper.Map<Book>(It.IsAny<AddBookDto>()))
                .Returns((AddBookDto dto) => new Book
                {
                    BookId = ExampleBookId,
                    Title = dto.Title,
                    Genre = dto.Genre,
                    Description = dto.Description,
                    AuthorId = dto.AuthorId
                });

            // Set up mock to map from Book to GetBookDto
            _mockMapper.Setup(mapper => mapper.Map<GetBookDto>(It.IsAny<Book>()))
                .Returns((Book book) => new GetBookDto
                {
                    Title = book.Title,
                    Genre = book.Genre,
                    Description = book.Description,
                    AuthorId = (Guid)book.AuthorId
                });

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
            AddBookDto bookToTest = new()
            {
                Title = null!,
                Genre = "Fantasy",
                AuthorId = Guid.NewGuid(),
                Description = "An example book for Testing"
            };
            var command = new AddBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.EqualTo(false));
        }
    }
}
