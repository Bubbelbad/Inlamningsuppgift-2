using Application.Commands.AuthorCommands.AddAuthor;
using Application.Dtos;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TestProject.AuthorIntegrationTests
{
    [TestFixture]
    [Category("Author/Integration/AddAuthor")]
    public class AddAuthorIntegrationTest
    {
        private AddAuthorCommandHandler _handler;
        private RealDatabase _database;
        private IAuthorRepository _repository;
        private IMapper _mapper;

        private static readonly Guid ExampleAuthorId = new Guid("12345678-1234-1234-1234-1234567890ab");

        [SetUp]
        public void Setup()
        {
            // Set up in-memory database
            var options = new DbContextOptionsBuilder<RealDatabase>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _database = new RealDatabase(options);

            // Initialize the repository with the in-memory database
            _repository = new AuthorRepository(_database);

            // Set up AutoMapper with actual configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddAuthorDto, Author>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => ExampleAuthorId));
            });
            _mapper = config.CreateMapper();

            // Initialize the handler with the actual repository and mapper
            _handler = new AddAuthorCommandHandler(_repository, _mapper);
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up the in-memory database
            _database.Database.EnsureDeleted();
            _database.Dispose();
        }

        [Test]
        public async Task Handle_ValidInput_ReturnsCorrectAuthor()
        {
            // Arrange
            AddAuthorDto authorToTest = new("Test", "Testsson");
            var command = new AddAuthorCommand(authorToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.FirstName, Is.EqualTo(authorToTest.FirstName));
        }

        [Test]
        public async Task Handle_InvalidInput_ReturnsFailure()
        {
            // Arrange
            AddAuthorDto authorToTest = new(null!, "Testsson");
            var command = new AddAuthorCommand(authorToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.EqualTo(false));
        }
    }
}
