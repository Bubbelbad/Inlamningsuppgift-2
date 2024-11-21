using Domain.Model;
using Infrastructure.Database;
using MediatR;


namespace Application.Services
{
    public class AuthorService(FakeDatabase database)
    {
        internal readonly IMediator _mediator;
        private readonly FakeDatabase _database = database;


        //public async Task<Author> GetAuthorById(Guid authorId)
        //{
        //    var author = await _database.GetAuthorById(authorId);
        //    return author;
        //}

        public async Task<Author> AddNewAuthor(Author authorId)
        {
            Author addedAuthor = await _database.AddNewAuthor(authorId);
            return addedAuthor;
        }


        public async Task<Author> UpdateAuthor(Author author)
        {
            Author updatedAuthor = await _database.UpdateAuthor(author);
            return updatedAuthor;
        }

        public async Task<Author> DeleteAuthor(Guid id)
        {
            var result = await _database.DeleteAuthor(id);
            return result;
        }
    }
}
