using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper) : IRequestHandler<UpdateBookCommand, OperationResult<Book>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public IMapper _mapper = mapper;

        public async Task<OperationResult<Book>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.NewBook == null || string.IsNullOrEmpty(request.NewBook.Title))
            {
                return OperationResult<Book>.Failure("Invalid input");
            }

            try
            {
                Book bookToUpdate = new()
                {
                    BookId = request.NewBook.Id,
                    Title = request.NewBook.Title,
                    AuthorId = request.NewBook.AuthorId,
                    Description = request.NewBook.Description
                };

                var updatedBook = await _bookRepository.UpdateBook(bookToUpdate);

                var mappedBook = _mapper.Map<Book>(updatedBook);

                return OperationResult<Book>.Success(mappedBook);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred.", ex);
            }
        }
    }
}
