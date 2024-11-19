using Application.Dtos;
using Domain.Model;
using MediatR;

namespace Application.Commands.AddAuthor
{
    public class AddAuthorCommand(AuthorDto author) : IRequest<Author>
    {
        public AuthorDto NewAuthor { get; set } = author; 
    }
}
