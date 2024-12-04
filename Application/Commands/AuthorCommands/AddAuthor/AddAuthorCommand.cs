using Application.Dtos;
using Domain.Model;
using MediatR;

namespace Application.Commands.AddAuthorCommands.AddAuthor
{
    public class AddAuthorCommand(AddAuthorDto author) : IRequest<OperationResult<Author>>
    {
        public AddAuthorDto NewAuthor { get; set; } = author; 
    }
}
