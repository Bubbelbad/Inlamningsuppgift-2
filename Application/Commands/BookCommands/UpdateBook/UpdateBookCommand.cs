using Application.Dtos.BookDtos;
using Application.Models;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommand(BookDto bookToUpdate) : IRequest<OperationResult<Book>>
    {
        public BookDto NewBook { get; set; } = bookToUpdate;
    }
}
