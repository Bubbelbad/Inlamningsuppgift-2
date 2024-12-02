using Application.Interfaces.RepositoryInterfaces;
using Application.Queries.AuthorQueries;
using Domain.Model;
using Moq;

namespace TestProject.AuthorUnitTests
{
    [TestFixture]
    public class GetAuthorUnitTest
    {
        private Mock<IAuthorRepository> _mockRepository;
        private GetAuthorByIdQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IAuthorRepository>();

            // Set up the mock repository to return a specific Author for a valid ID
            var validAuthorId = new Guid("fc22325e-0fa3-4615-aa6c-c7fe459a2735");
            var author = new Author(validAuthorId, "Test", "Author");

            _mockRepository.Setup(repo => repo.GetAuthorById(It.Is<Guid>(id => id == validAuthorId)))
                           .ReturnsAsync(author);

            // Set up the mock repository to return null for any other ID
            _mockRepository.Setup(repo => repo.GetAuthorById(It.Is<Guid>(id => id != validAuthorId)))
                           .ReturnsAsync((Author)null);

            _handler = new GetAuthorByIdQueryHandler(_mockRepository.Object);
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
