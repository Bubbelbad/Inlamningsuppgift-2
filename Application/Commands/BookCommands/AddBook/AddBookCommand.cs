using Application.Dtos;
using Domain.Model;
using MediatR;

namespace Application.Commands.BookCommands.AddBook
{
    public class AddBookCommand(AddBookDto bookToCreate) : IRequest<OperationResult<Book>>
    {
        public AddBookDto NewBook { get; } = bookToCreate;
    }
}
