using Application.Interfaces.RepositoryInterfaces;
using Application.Queries.AuthorQueries.GetAuthorById;
using AutoMapper;
using Domain.Entities.Core;
using Moq;

namespace TestProject.AuthorUnitTests
{
    [TestFixture]
    [Category("Author/UnitTests/GetAuthorById")]
    public class GetAuthorUnitTest
    {
        private Mock<IGenericRepository<Author, Guid>> _mockRepository;
        private GetAuthorByIdQueryHandler _handler;
        private Mock<IMapper> _mockMapper;

        private static readonly Guid ExampleAuthorId = Guid.Parse("fc22325e-0fa3-4615-aa6c-c7fe459a2735");
        private static readonly Author ExampleAuthor = new Author { AuthorId = ExampleAuthorId, FirstName = "Test", LastName = "AuthorId" };

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IGenericRepository<Author, Guid>>();
            _mockMapper = new Mock<IMapper>();

            _mockRepository.Setup(repo => repo.GetByIdAsync(It.Is<Guid>(id => id == ExampleAuthorId)))
                           .ReturnsAsync(ExampleAuthor);

            // Set up the mock repository to return null for any other ID
            _mockRepository.Setup(repo => repo.GetByIdAsync(It.Is<Guid>(id => id != ExampleAuthorId)))
                           .ReturnsAsync((Author)null!);

            _mockMapper.Setup(Setup => Setup.Map<Author>(It.IsAny<Author>()))
                       .Returns((Author author) => author);

            _handler = new GetAuthorByIdQueryHandler(_mockRepository.Object, _mockMapper.Object);
        }

        [Test]
        public async Task Handle_ValidId_ReturnsCorrectAuthor()
        {
            // Arrange
            var query = new GetAuthorByIdQuery(ExampleAuthorId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.AuthorId, Is.EqualTo(ExampleAuthorId));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidAuthorId = Guid.NewGuid();
            var query = new GetAuthorByIdQuery(invalidAuthorId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result.Data, Is.Null);
        }
    }
}
