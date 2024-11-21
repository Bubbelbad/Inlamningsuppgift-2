using Application.Dtos;
using Domain.Model;
using MediatR;
using System.Security.Cryptography.X509Certificates;

namespace Application.Commands.AuthorCommands.UpdateAuthor
{
    public class UpdateAuthorCommand(AuthorDto authorToUpdate) : IRequest<Author>
    {
        public AuthorDto NewAuthor { get; set; } = authorToUpdate;  
    }
}
