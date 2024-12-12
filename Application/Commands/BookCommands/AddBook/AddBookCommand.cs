using Application.Dtos;
using Application.Models;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.BookCommands.AddBook
{
    public class AddBookCommand(AddBookDto bookToCreate) : IRequest<OperationResult<Book>>
    {
        public AddBookDto NewBook { get; } = bookToCreate;
    }
}
