using Application.Dtos;
using Domain.Model;
using MediatR;
using System.Security.Cryptography.X509Certificates;

namespace Application.Commands.AuthorCommands.UpdateAuthor
{
    public class UpdateAuthorCommand(AuthorDto authorToUpdate) : IRequest<Author>
    {
        public Guid Id { get; set; } = authorToUpdate.Id;
        public string FirstName { get; set; } = authorToUpdate.FirstName;
        public string LastName { get; set; } = authorToUpdate.LastName; 

    }
}
