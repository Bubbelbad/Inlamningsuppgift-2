using Application.Dtos.BookDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.BookCommands.AddBook
{
    public class AddBookCommandHandler(IBookRepository bookRepository, IMapper mapper) : IRequestHandler<AddBookCommand, OperationResult<AddBookDto>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public readonly IMapper _mapper = mapper;

        public async Task<OperationResult<AddBookDto>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            // var existingAuthor = _database.Authors.Where(author => author.Id == request.NewBook.AuthorId.Id);
            // Kolla om det finns existerande author eller om en ny ska läggas till

            if (request == null || request.NewBook == null || string.IsNullOrEmpty(request.NewBook.Title))
            {
                return OperationResult<AddBookDto>.Failure("Not valid input"); //Is this if-statement really needed with my ModelState now ? 
            }
            try
            {
                Book bookToCreate = new()
                {
                    BookId = Guid.NewGuid(),
                    Title = request.NewBook.Title,
                    Genre = request.NewBook.Genre,
                    Description = request.NewBook.Description,
                    AuthorId = request.NewBook.AuthorId
                };

                var createdBook = await _bookRepository.AddBook(bookToCreate);
                var mappedBook = _mapper.Map<AddBookDto>(createdBook);

                return OperationResult<AddBookDto>.Success(mappedBook);
            }
            catch
            {
                throw new Exception("Book not added");
            }
        }
    }
}
