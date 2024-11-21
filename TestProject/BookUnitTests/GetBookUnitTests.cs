using Infrastructure.Database;
using Application.Queries.BookQueries;

namespace TestProject.BookUnitTests
{
    [TestFixture]
    public class GetBookUnitTests
    {
        private FakeDatabase _database;
        private GetBookByIdQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _database = new FakeDatabase();
            _handler = new GetBookByIdQueryHandler(_database);
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
