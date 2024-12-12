using Application.Dtos;
using Application.Models;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.AuthorCommands.UpdateAuthor
{
    public class UpdateAuthorCommand(AuthorDto authorToUpdate) : IRequest<OperationResult<Author>>
    {
        public AuthorDto NewAuthor { get; set; } = authorToUpdate;
    }
}
