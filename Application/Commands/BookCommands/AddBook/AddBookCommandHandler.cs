using Application.Dtos.BookDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.BookCommands.AddBook
{
    public class AddBookCommandHandler(IGenericRepository<Book, Guid> repository, IMapper mapper) : IRequestHandler<AddBookCommand, OperationResult<GetBookDto>>
    {
        private readonly IGenericRepository<Book, Guid> _repository = repository;
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
                    AuthorId = request.NewBook.AuthorId,
                    PublisherId = request.NewBook.PublisherId,
                    ImageUrl = request.NewBook.ImageUrl
                };

                var createdBook = await _repository.AddAsync(bookToCreate);
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
