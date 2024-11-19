using Application.Dtos;
using Domain.Model;
using MediatR;

namespace Application.Commands.AddBook
{
    public class AddBookCommand(BookDto bookToCreate) : IRequest<Book>
    {
        public BookDto NewBook { get; } = bookToCreate;
    }
}
