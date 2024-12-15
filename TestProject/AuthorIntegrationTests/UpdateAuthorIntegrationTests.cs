using Application.Commands.AuthorCommands.UpdateAuthor;
using Application.Dtos;
using Application.Dtos.AuthorDtos;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Entities.Core;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TestProject.AuthorIntegrationTests
{
    [TestFixture]
    [Category("AuthorId/Integration/UpdateAuthor")]
    public class UpdateAuthorIntegrationTests
    {
        private UpdateAuthorCommandHandler _handler;
        private RealDatabase _database;
        private IGenericRepository<Author, Guid> _repository;
        private IMapper _mapper;

        private static readonly Guid ExampleAuthorId = new("12345678-1234-1234-1234-1234567890ab");
        private static readonly Author ExampleAuthorDto = new()
        {
            AuthorId = ExampleAuthorId,
            FirstName = "Test",
            LastName = "Testsson"
        };

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
                cfg.CreateMap<AuthorDto, Author>()
                   .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => ExampleAuthorId));
            });
            _mapper = config.CreateMapper();

            Author author = new() { AuthorId = ExampleAuthorId, FirstName = "Test", LastName = "Testsson" };
            _database.Authors.Add(author);
            _database.SaveChanges();

            // Initialize the handler with the actual repository and mapper
            _handler = new UpdateAuthorCommandHandler(_repository, _mapper);
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up the in-memory database
            _database.Database.EnsureDeleted();
            _database.Dispose();
        }

        [Test]
        public async Task Handle_ValidInput_ResurnsTrue()
        {
            // Arrange
            var updatedAuthor = new UpdateAuthorDto
            {
                AuthorId = ExampleAuthorId,
                FirstName = "Test",
                LastName = "Testsson",
                DateOfBirth = DateTime.Now,
                Biography = "Biography"
            };

            // Act
            var result = await _handler.Handle(new UpdateAuthorCommand(updatedAuthor), CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.FirstName, Is.EqualTo(ExampleAuthorDto.FirstName));
            Assert.That(result.Data.LastName, Is.EqualTo(ExampleAuthorDto.LastName));
        }

        [Test]
        public async Task Handle_NullInput_ReturnsNull()
        {
            // Arrange
            UpdateAuthorDto authorToTest = null!;
            var command = new UpdateAuthorCommand(authorToTest);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result.IsSuccess, Is.EqualTo(false));
        }

        [Test]
        public async Task Handle_MissingFirstName_ReturnsNull()
        {
            // Arrange
            var invalidAuthorDto = new UpdateAuthorDto
            {
                AuthorId = Guid.NewGuid(),
                FirstName = null!,
                LastName = "Updatedsson",
                DateOfBirth = DateTime.Now,
                Biography = "Biography"
            };

            var command = new UpdateAuthorCommand(invalidAuthorDto);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result.IsSuccess, Is.EqualTo(false));
        }
    }
}
