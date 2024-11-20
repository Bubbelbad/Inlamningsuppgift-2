using Application;
using Application.Commands.UpdateBook;
using Application.Dtos;
using Domain.Model;
using Infrastructure.Database;

namespace TestProject
{
    [TestFixture]
    public class UpdateBookUnitTest
    {
        private UpdateBookCommandHandler _handler;
        private FakeDatabase _database; 

        [SetUp]
        public void Setup()
        {
            _database = new FakeDatabase(); 
            _handler = new UpdateBookCommandHandler(_database);
        }

        [Test, Category("UpdateBook")]
        public async Task Handle_ValidBookDto_ReturnsTrue()
        {
            // Arrange
            BookDto bookToTest = new(new Guid("12345678-1234-5678-1234-567812345678"), "Test", "Victor", "BookService for Testing");

            var query = new UpdateBookCommand(bookToTest);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }
    }
}
