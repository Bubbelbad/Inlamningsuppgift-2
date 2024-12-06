using Application.Interfaces.RepositoryInterfaces;
using Application.Commands.UserCommands.AddUser;
using Application.Dtos;
using Domain.Model;
using Moq;

namespace TestProject.UserUnitTests
{
    [TestFixture]
    [Category("User/UnitTests/AddUser")]
    public class AddUserUnitTest
    {
        private Mock<IUserRepository> _mockRepository;
        private AddNewUserCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IUserRepository>();

            var validUserId = new Guid("59ca7b98-b918-4ff1-a7f8-83d2777021e9");
            User user = new() { Id = validUserId, UserName = "Test", Password = "Test" };

            _mockRepository.Setup(repo => repo.AddUser(It.Is<User>(user => user.Id == validUserId)))
                           .ReturnsAsync(user);

            _mockRepository.Setup(repo => repo.AddUser(It.Is<User>(user => user.Id != validUserId)))
                           .ReturnsAsync((User)null!);

            _handler = new AddNewUserCommandHandler(_mockRepository.Object);
        }

        [Test]
        public async Task Handle_ValidInput_ReturnsUser()
        {
            // Arrange
            Guid validUserId = new Guid("59ca7b98-b918-4ff1-a7f8-83d2777021e9");
            UserDto userToTest = new() {  UserName = "Test", Password = "Test" };

            // Act
            var command = new AddNewUserCommand(userToTest);
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}
