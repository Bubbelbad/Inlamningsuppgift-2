using Application.Queries.BookQueries;
using Application.Interfaces.RepositoryInterfaces;
using Moq;
using Domain.Model;

namespace TestProject.BookUnitTests
{
    [TestFixture]
    public class GetBookUnitTests
    {
        private Mock<IBookRepository> _mockRepository; 
        private GetBookByIdQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockRepository = new Mock<IBookRepository>();

            Guid validBookGuid = new Guid("2bfaf5e9-d978-464c-b778-7567ef2dde29");
            var book = new Book(validBookGuid, "Test", "Test", "Test");

            _mockRepository.Setup(repo => repo.GetBookById(It.Is<Guid>(id => id == validBookGuid)))
                           .ReturnsAsync(book);

            _mockRepository.Setup(repo => repo.GetBookById(It.Is<Guid>(id => id != validBookGuid)))
                           .ReturnsAsync((Book)null);

            _handler = new GetBookByIdQueryHandler(_mockRepository.Object);
        }

        [Test, Category("GetBook")]
        public async Task Handle_ValidId_ReturnsCorrectBook()
        {
            // Arrange
            var bookId = new Guid("2bfaf5e9-d978-464c-b778-7567ef2dde29");

            var query = new GetBookByIdQuery(bookId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(bookId));
        }

        [Test, Category("GetBook")]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidBookId = Guid.NewGuid();

            var query = new GetBookByIdQuery(invalidBookId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
