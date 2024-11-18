using Application.Services;
using Domain.Model;
using Infrastructure.Database;

namespace TestProject
{
    class AuthorUnitTest
    {
        [Test]
        public async Task AddAuthor_WhenGivenCorrectParams_AuthorAddedToList()
        {
            FakeDatabase fakeRepository = new();
            AuthorService authorService = new(fakeRepository); 
            Author authorToTest = new(1, "Victor", "Ivarson");

            // Act
            var authorCreated = await authorService.AddNewAuthor(authorToTest);

            // Assert
            Assert.That(authorCreated, Is.Not.Null);
            Assert.That(authorCreated.FirstName, Is.EqualTo(authorToTest.FirstName));
        }

        [Test]
        public async Task GetAuthorById_ReturnsAuthor()
        {
            var fakeDatabase = new FakeDatabase();
            var authorService = new AuthorService(fakeDatabase);
            string expectedFirstName = "Victor";

            // Act 
            var result = await authorService.GetAuthorById(1);

            // Assert
            Assert.That(result.FirstName, Is.EqualTo(expectedFirstName));
        }

        [Test]
        public async Task UpdateAuthor_ReturnsUpdatedAuthor()
        {
            FakeDatabase fakeDatabase = new();
            AuthorService authorService = new(fakeDatabase);
            var updatedAuthor = new Author(1, "AnnanBok", "Vulle");

            // Act 
            await authorService.UpdateAuthor(updatedAuthor);

            // Assert
            var result = await authorService.GetAuthorById(1);
            Assert.That(result.FirstName, Is.EqualTo(updatedAuthor.FirstName));
        }

        [Test]
        public async Task DeleteAuthor_ReturnsOk()
        {
            // Arrange
            FakeDatabase fakeDatabase = new();
            AuthorService authorService = new(fakeDatabase);

            // Act 
            var result = await authorService.DeleteAuthor(1);

            // Assert
            Assert.That(result, Is.Not.EqualTo(null));
        }
    }
}
