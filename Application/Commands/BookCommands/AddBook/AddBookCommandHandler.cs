using Application.Dtos.BookDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.BookCommands.AddBook
{
    public class AddBookCommandHandler(IBookRepository bookRepository, IMapper mapper) : IRequestHandler<AddBookCommand, OperationResult<GetBookDto>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetBookDto>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
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
                var mappedBook = _mapper.Map<GetBookDto>(createdBook);

                return OperationResult<GetBookDto>.Success(mappedBook);
            }
            catch
            {
                throw new Exception("Book not added");
            }
        }
    }
}
