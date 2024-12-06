using Application.Queries.BookQueries;
using Application.Interfaces.RepositoryInterfaces;
using Moq;
using Domain.Model;
using AutoMapper;

namespace TestProject.BookUnitTests
{
    [TestFixture]
    [Category("Book/UnitTests/GetBookById")]
    public class GetBookUnitTests
    {
        private GetBookByIdQueryHandler _handler;
        private Mock<IBookRepository> _mockRepository;
        private Mock<IMapper> _mockMapper;

        private static readonly Guid ExampleBookId = Guid.Parse("2bfaf5e9-d978-464c-b778-7567ef2dde29");
        private static readonly Book ExampleBook = new(ExampleBookId, "Test", "Test", "Test");

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<IBookRepository>();
            _mockMapper = new Mock<IMapper>();

            // Setup the mock repository to return the same book object
            _mockRepository.Setup(repo => repo.GetBookById(It.Is<Guid>(id => id == ExampleBookId)))
                           .ReturnsAsync(ExampleBook);

            _mockRepository.Setup(repo => repo.GetBookById(It.Is<Guid>(id => id != ExampleBookId)))
                           .ReturnsAsync((Book)null!);

            // Setup the mock mapper to return the same book object
            _mockMapper.Setup(mapper => mapper.Map<Book>(It.IsAny<Book>()))
                       .Returns((Book source) => source);

            _handler = new GetBookByIdQueryHandler(_mockRepository.Object, _mockMapper.Object);
        }

        [Test]
        public async Task Handle_ValidId_ReturnsCorrectBook()
        {
            // Arrange
            var query = new GetBookByIdQuery(ExampleBookId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Data.Id, Is.EqualTo(ExampleBookId));
        }

        [Test]
        public async Task Handle_NonExisitingId_ReturnsNull()
        {
            // Arrange
            var query = new GetBookByIdQuery(Guid.NewGuid());

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result.IsSuccess, Is.EqualTo(false));
        }
    }
}
