using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using MediatR;

namespace Application.Commands.UpdateBook
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
                var bookToUpdate = new Book(request.NewBook.Id, request.NewBook.Title, request.NewBook.Author, request.NewBook.Description);

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
