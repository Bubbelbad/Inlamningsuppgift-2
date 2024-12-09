using Application.Interfaces.RepositoryInterfaces;
using Application.Commands.UserCommands.Register;
using Application.Dtos;
using Domain.Model;
using Moq;
using AutoMapper;
using Application.Interfaces.ServiceInterfaces;

namespace TestProject.UserUnitTests
{
    [TestFixture]
    [Category("User/UnitTests/Register")]
    public class AddUserUnitTest
    {
        private Mock<IUserRepository> _mockRepository;
        private Mock<IPasswordEncryptionService> _mockEncryption;
        private RegisterCommandHandler _handler;
        private Mock<IMapper> _mockMapper;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockEncryption = new Mock<IPasswordEncryptionService>();

            var validUserId = new Guid("59ca7b98-b918-4ff1-a7f8-83d2777021e9");
            User user = new() { Id = validUserId, UserName = "Test", Password = "Test" };

            _mockRepository.Setup(repo => repo.AddUser(It.Is<User>(user => user.Id == validUserId)))
                           .ReturnsAsync(user);

            _mockRepository.Setup(repo => repo.AddUser(It.Is<User>(user => user.Id != validUserId)))
                           .ReturnsAsync((User)null!);

            _handler = new RegisterCommandHandler(_mockRepository.Object, _mockMapper.Object, _mockEncryption.Object);
        }

        [Test]
        public async Task Handle_ValidInput_ReturnsUser()
        {
            // Arrange
            UserDto userToTest = new() { UserName = "Test", Password = "Test" };

            // Act
            var command = new RegisterCommand(userToTest);
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}
