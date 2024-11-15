using Application.Interfaces;
using Domain;
using Domain.Model;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthorService(FakeDatabase database) : IAuthorService
    {
        private readonly FakeDatabase _database = database;


        public async Task<Author> GetAuthorById(int authorId)
        {
            var author = await _database.GetAuthorById(authorId);
            return author;
        }

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

        public async Task<Author> DeleteAuthor(int id)
        {
            var result = await _database.DeleteAuthor(id);
            return result;
        }
    }
}
