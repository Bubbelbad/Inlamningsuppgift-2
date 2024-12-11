using Application.Dtos;
using Domain.Model;
using MediatR;

namespace Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommand(BookDto bookToUpdate) : IRequest<OperationResult<Book>>
    {
        public BookDto NewBook { get; set; } = bookToUpdate;
    }
}
