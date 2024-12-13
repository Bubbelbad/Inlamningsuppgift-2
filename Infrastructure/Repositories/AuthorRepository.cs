using Application.Interfaces.RepositoryInterfaces;
using Domain.Entities.Core;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class AuthorRepository(RealDatabase database) : IAuthorRepository
    {
        private readonly RealDatabase _realDatabase = database;

        public async Task<List<Author>> GetAllAuthors()
        {
            return _realDatabase.Authors.ToList();
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            Author author = _realDatabase.Authors.FirstOrDefault(author => author.AuthorId == id);
            return author;
        }

        public async Task<Author> AddAuthor(Author author)
        {
            _realDatabase.Authors.Add(author);
            _realDatabase.SaveChanges();
            return author;
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            Author authorToUpdate = _realDatabase.Authors.FirstOrDefault(obj => obj.AuthorId == author.AuthorId);
            if (authorToUpdate is not null)
            {
                authorToUpdate.AuthorId = author.AuthorId;
                authorToUpdate.FirstName = author.FirstName;
                authorToUpdate.LastName = author.LastName;
                authorToUpdate.DateOfBirth = author.DateOfBirth;
                authorToUpdate.Biography = author.Biography;
                _realDatabase.Update(authorToUpdate);
                _realDatabase.SaveChanges();
            }
            return authorToUpdate;
        }

        public async Task<bool> DeleteAuthor(Guid id)
        {
            bool actionSuccessful = false;
            var authorToDelete = _realDatabase.Authors.FirstOrDefault(author => author.AuthorId == id);
            if (authorToDelete is not null)
            {
                _realDatabase.Authors.Remove((Author)authorToDelete);
                _realDatabase.SaveChanges();
                actionSuccessful = true;
            }
            return await Task.FromResult(actionSuccessful);
        }
    }
}
