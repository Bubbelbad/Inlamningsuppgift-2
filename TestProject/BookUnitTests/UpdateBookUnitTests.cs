using Application.Commands.BookCommands.UpdateBook;
using Application.Dtos.BookDtos;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Entities.Core;
using Moq;

namespace TestProject.BookUnitTests
{
    [TestFixture]
    [Category("Book/UnitTests/UpdateBook")]
    public class UpdateBookUnitTest
    {
        private UpdateBookCommandHandler _handler;
        private Mock<IGenericRepository<Book, Guid>> _mockRepository;
        private Mock<IMapper> _mockMapper;

        private static readonly Guid ExampleBookId = Guid.Parse("3e2e66cf-5ba6-4cd0-88a1-c37b71cca899");
        private static readonly Book ExampleBook = new()
        {
            BookId = ExampleBookId,
            Title = "Test",
            Genre = "Fantasy",
            Description = "Test",
            AuthorId = Guid.NewGuid(),
        };

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IGenericRepository<Book, Guid>>();
            _mockMapper = new Mock<IMapper>();

            _mockRepository.Setup(repo => repo.UpdateAsync(It.Is<Book>(obj => obj.BookId == ExampleBookId)))
                           .ReturnsAsync(ExampleBook);

            _mockRepository.Setup(repo => repo.GetByIdAsync(It.Is<Guid>(id => id == ExampleBookId)))
                           .ReturnsAsync(ExampleBook);

            _mockMapper.Setup(mapper => mapper.Map<Book>(It.IsAny<UpdateBookDto>()))
                       .Returns((UpdateBookDto dto) => new Book
                       {
                           BookId = dto.Id,
                           Title = dto.Title,
                           Genre = dto.Genre,
                           Description = dto.Description,
                           AuthorId = dto.AuthorId
                       });

            _mockMapper.Setup(mapper => mapper.Map<GetBookDto>(It.IsAny<Book>()))
                       .Returns((Book book) => new GetBookDto
                       {
                           BookId = book.BookId,
                           Title = book.Title,
                           Genre = book.Genre,
                           Description = book.Description,
                           AuthorId = (Guid)book.AuthorId
                       });

            _handler = new UpdateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);
        }

        [Test]
        public async Task Handle_ValidInput_ReturnsBook()
        {
            // Arrange
            UpdateBookDto bookToTest = new UpdateBookDto
            {
                Id = ExampleBookId,
                Title = "Test",
                Genre = "Fantasy",
                Description = "Test",
                AuthorId = Guid.NewGuid(),
            };
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
            UpdateBookDto bookToTest = null!; // Use null-forgiving operator to explicitly indicate null
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
            UpdateBookDto bookToTest = new UpdateBookDto
            {
                Id = new Guid("12345678-1234-5678-1234-567812345678"),
                Title = null!,
                AuthorId = Guid.NewGuid(),
                Description = "BookService for Testing"
            };
            var command = new UpdateBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result.Data, Is.EqualTo(null));
        }
    }
}
