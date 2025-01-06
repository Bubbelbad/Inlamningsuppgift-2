using Application.Dtos.BookDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommandHandler(IGenericRepository<Book, Guid> repository, IMapper mapper) : IRequestHandler<UpdateBookCommand, OperationResult<GetBookDto>>
    {
        private readonly IGenericRepository<Book, Guid> _repository = repository;
        public IMapper _mapper = mapper;

        public async Task<OperationResult<GetBookDto>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Book bookToUpdate = new()
                {
                    BookId = request.NewBook.BookId,
                    Title = request.NewBook.Title,
                    Genre = request.NewBook.Genre,
                    Description = request.NewBook.Description,
                    AuthorId = request.NewBook.AuthorId,
                    PublisherId = request.NewBook.PublisherId,
                    ImageUrl = request.NewBook.ImageUrl
                };

                var updatedBook = await _repository.UpdateAsync(bookToUpdate);
                var mappedBook = _mapper.Map<GetBookDto>(updatedBook);

                return OperationResult<GetBookDto>.Success(mappedBook);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred.", ex);
            }
        }
    }
}
