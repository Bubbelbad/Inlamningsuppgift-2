using Domain.Model;


namespace Application.Interfaces
{
    internal interface IAuthorService
    {
        public Task<Author> AddNewAuthor(Author author);
        public Task<Author> GetAuthorById(int id);
        public Task<Author> UpdateAuthor(Author author);
        public Task<Author> DeleteAuthor(int id);
    }               
}
