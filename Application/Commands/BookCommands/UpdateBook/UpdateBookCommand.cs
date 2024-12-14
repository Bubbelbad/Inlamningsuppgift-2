using Application.Dtos.BookDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommand(UpdateBookDto bookToUpdate) : IRequest<OperationResult<GetBookDto>>
    {
        public UpdateBookDto NewBook { get; set; } = bookToUpdate;
    }
}
