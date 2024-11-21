using Application.Queries.AuthorQueries;
using Infrastructure.Database;

namespace TestProject.AuthorUnitTests
{
    [TestFixture]
    public class GetAuthorUnitTest
    {
        private FakeDatabase _database;
        private GetAuthorByIdQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _database = new FakeDatabase();
            _handler = new GetAuthorByIdQueryHandler(_database);
        }

        [Test, Category("GetAuthor")]
        public async Task Handle_ValidId_ReturnsCorrectAuthor()
        {
            // Arrange
            var authorId = new Guid("fc22325e-0fa3-4615-aa6c-c7fe459a2735");

            var query = new GetAuthorByIdQuery(authorId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(authorId));
        }

        [Test, Category("GetAuthor")]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidAuthorId = Guid.NewGuid();

            var query = new GetAuthorByIdQuery(invalidAuthorId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
