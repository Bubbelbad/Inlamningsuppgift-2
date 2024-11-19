using Application.Dtos;
using Domain.Model;
using MediatR;

namespace Application.Commands.UpdateBook
{
    public class UpdateBookCommand(BookDto bookToUpdate) : IRequest<Book>
    {
        public BookDto UpdatedBook { get; } = bookToUpdate;
    }
}
