using Application.Interfaces.RepositoryInterfaces;
using Domain.Model;
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

        public async Task<Author> AddAuthor(Author author)
        {
            _realDatabase.Authors.Add(author);
            _realDatabase.SaveChanges();
            return author; 
        }

        public async Task<bool> DeleteAuthor(Guid id)
        {
            bool actionSuccessful = false;
            var authorToDelete = _realDatabase.Authors.Where(author => author.Id == id).First();
            if (authorToDelete is not null)
            {
                _realDatabase.Authors.Remove(authorToDelete); 
                _realDatabase.SaveChanges();
                actionSuccessful = true;
            }
            return await Task.FromResult(actionSuccessful);
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            Author author = _realDatabase.Authors.FirstOrDefault(author => author.Id == id);
            return author; 
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
