using Application.Dtos.BookDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper) : IRequestHandler<UpdateBookCommand, OperationResult<GetBookDto>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public IMapper _mapper = mapper;

        public async Task<OperationResult<GetBookDto>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Book bookToUpdate = new()
                {
                    BookId = request.NewBook.Id,
                    Title = request.NewBook.Title,
                    Genre = request.NewBook.Genre,
                    Description = request.NewBook.Description,
                    AuthorId = request.NewBook.AuthorId,
                };

                var updatedBook = await _bookRepository.UpdateBook(bookToUpdate);
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
