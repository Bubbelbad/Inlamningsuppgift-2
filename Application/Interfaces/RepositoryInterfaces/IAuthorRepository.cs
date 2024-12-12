using Domain.Entities.Core;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface IAuthorRepository
    {
        Task<Author> AddAuthor(Author author);
        Task<List<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(Guid id);
        Task<Author> UpdateAuthor(Author author);
        Task<bool> DeleteAuthor(Guid id);
    }
}
