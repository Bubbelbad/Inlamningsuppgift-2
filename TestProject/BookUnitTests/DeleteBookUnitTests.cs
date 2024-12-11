using Application.Commands.BookCommands.DeleteBook;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Moq;

namespace TestProject.BookUnitTests
{
    [TestFixture]
    [Category("Book/UnitTests/DeleteBook")]
    public class DeleteBookUnitTest
    {
        private DeleteBookCommandHandler _handler;
        private Mock<IBookRepository> _mockRepository;
        private Mock<IMapper> _mockMapper;

        private static readonly Guid ExampleBookId = Guid.Parse("783307e1-ea3b-400b-919d-0c40b2bbae78");

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IBookRepository>();
            _mockMapper = new Mock<IMapper>();

            // Setup mock.DeleteBook returns true when valid ID
            _mockRepository.Setup(repo => repo.DeleteBook(It.Is<Guid>(id => id == new Guid("783307e1-ea3b-400b-919d-0c40b2bbae78"))))
                           .ReturnsAsync(true);

            _mockRepository.Setup(repo => repo.DeleteBook(It.Is<Guid>(id => id != new Guid("783307e1-ea3b-400b-919d-0c40b2bbae78"))))
                           .ReturnsAsync(false);

            _handler = new DeleteBookCommandHandler(_mockRepository.Object, _mockMapper.Object);
        }

        [Test]
        public async Task Handle_ValidInputId_ReturnsTrue()
        {
            // Arrange
            var command = new DeleteBookCommand(ExampleBookId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result.IsSuccess, Is.EqualTo(true));
        }

        [Test]
        public async Task Handle_NonExistingBookId_ReturnsFalse()
        {
            // Arrange
            var command = new DeleteBookCommand(Guid.NewGuid());

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result.IsSuccess, Is.EqualTo(false));
        }
    }
}
