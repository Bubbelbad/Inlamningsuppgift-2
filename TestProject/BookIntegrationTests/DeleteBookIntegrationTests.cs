using Application.Commands.BookCommands.DeleteBook;
using Application.Dtos;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


namespace TestProject.BookIntegrationTests
{
    [TestFixture]
    [Category("Book/Integration/DeleteBook")]
    internal class DeleteBookIntegrationTests
    {
        private DeleteBookCommandHandler _handler;
        private RealDatabase _database;
        private IMapper _mapper;
        private IBookRepository _repository;

        private static readonly Guid ExampleBookId = new Guid("12345678-1234-1234-1234-1234567890ab");

        [SetUp]
        public void Setup()
        {
            // Set up in-memory database
            var options = new DbContextOptionsBuilder<RealDatabase>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _database = new RealDatabase(options);

            // Initialize the repository with the in-memory database
            _repository = new BookRepository(_database);

            // Set up AutoMapper with actual configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookDto, Book>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => ExampleBookId));
            });
            _mapper = config.CreateMapper();

            var book = new Book(ExampleBookId, "Test", "Testsson", "An example book for Testing");
            _database.Books.Add(book);
            _database.SaveChanges();

            // Initialize the handler with the actual repository and mapper
            _handler = new DeleteBookCommandHandler(_repository, _mapper);
        }

        [TearDown]
        public void TearDown()
        {
            _database.Database.EnsureDeleted();
            _database.Dispose();
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
