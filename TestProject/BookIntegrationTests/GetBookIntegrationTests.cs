using Application.Dtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Queries.BookQueries;
using AutoMapper;
using Domain.Model;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TestProject.BookIntegrationTests
{
    [TestFixture]
    [Category("Book/Integration/GetBook")]
    public class GetBookIntegrationTests
    {
        private GetBookByIdQueryHandler _handler;
        private RealDatabase _database;
        private IBookRepository _repository;
        private IMapper _mapper;

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

            // Add an author with ExampleAuthorId to the database
            var book = new Book(ExampleBookId, "Test", "Testsson", "Descriptive indeed");
            _database.Books.Add(book);
            _database.SaveChanges();

            // Initialize the handler with the actual repository and mapper
            _handler = new GetBookByIdQueryHandler(_repository, _mapper);
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up the in-memory database
            _database.Database.EnsureDeleted();
            _database.Dispose();
        }

        [Test]
        public async Task Handle_ValidId_ReturnsCorrectBook()
        {
            // Arrange
            var query = new GetBookByIdQuery(ExampleBookId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Data.Id, Is.EqualTo(ExampleBookId));
        }

        [Test]
        public async Task Handle_NonExisitingId_ReturnsNull()
        {
            // Arrange
            var query = new GetBookByIdQuery(Guid.NewGuid());

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result.IsSuccess, Is.EqualTo(false));
        }
    }
}
