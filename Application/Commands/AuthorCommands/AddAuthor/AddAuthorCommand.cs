using Application.Dtos;
using Application.Models;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.AuthorCommands.AddAuthor
{
    public class AddAuthorCommand(AddAuthorDto author) : IRequest<OperationResult<Author>>
    {
        public AddAuthorDto NewAuthor { get; set; } = author;
    }
}
