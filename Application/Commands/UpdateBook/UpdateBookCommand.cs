using Application.Dtos;
using Domain.Model;
using MediatR;

namespace Application.Commands.UpdateBook
{
    public class UpdateBookCommand(BookDto bookToUpdate) : IRequest<Book>
    {
        public Guid Id { get; } = bookToUpdate.Id; 
        public string Title { get; } = bookToUpdate.Title;
        public string Author { get; } = bookToUpdate.Author;
        public string Description { get; } = bookToUpdate.Description; 
    }
}
