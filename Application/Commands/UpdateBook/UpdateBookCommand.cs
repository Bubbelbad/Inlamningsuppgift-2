using Application.Dtos;
using Domain.Model;
using MediatR;

namespace Application.Commands.UpdateBook
{
    public class UpdateBookCommand(BookDto bookToUpdate) : IRequest<OperationResult<Book>>
    {
        public BookDto NewBook { get; set; } = bookToUpdate;
    }
}
