using Application.Commands.AuthorCommands.DeleteAuthor;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Moq;

namespace TestProject.AuthorUnitTests
{
    [TestFixture]
    [Category("Author/UnitTests/DeleteAuthor")]
    public class DeleteAuthorUnitTest
    {
        private DeleteAuthorCommandHandler _handler;
        private Mock<IAuthorRepository> _mockRepository;
        private Mock<IMapper> _mockMapper; 

        private static readonly Guid ExampleAuthorId = Guid.Parse("d1e16526-228e-4989-af4e-ee9690da3d8a");

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IAuthorRepository>();
            _mockMapper = new Mock<IMapper>();

            // Return true for a valid author ID
            _mockRepository.Setup(repo => repo.DeleteAuthor(It.Is<Guid>(id => id == ExampleAuthorId)))
                           .ReturnsAsync(true);

            // Return false for a non-existing author ID
            _mockRepository.Setup(repo => repo.DeleteAuthor(It.Is<Guid>(id => id != ExampleAuthorId)))
                           .ReturnsAsync(false);

            _handler = new DeleteAuthorCommandHandler(_mockRepository.Object, _mockMapper.Object);
        }

        [Test]
        public async Task Handle_ValidInputId_ReturnsTrue()
        {
            // Arrange
            var command = new DeleteAuthorCommand(ExampleAuthorId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result.IsSuccess, Is.EqualTo(true));
        }

        [Test]
        public async Task Handle_NonExistingBookId_ReturnsFalse()
        {
            // Arrange
            var command = new DeleteAuthorCommand(new Guid());

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result.IsSuccess, Is.EqualTo(false));
        }
    }
}
