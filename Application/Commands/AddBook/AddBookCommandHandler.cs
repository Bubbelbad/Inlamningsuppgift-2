using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using MediatR;

namespace Application.Commands.AddBook
{
    public class AddBookCommandHandler(IBookRepository bookRepository, IMapper mapper) : IRequestHandler<AddBookCommand, OperationResult<Book>>
    {
        private readonly IBookRepository _bookRepository = bookRepository; 
        public IMapper _mapper = mapper; 

        public async Task<OperationResult<Book>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            // var existingAuthor = _database.Authors.Where(author => author.Id == request.NewBook.Author.Id);
            // Kolla om det finns existerande author eller om en ny ska läggas till

            if (request == null || request.NewBook == null || string.IsNullOrEmpty(request.NewBook.Title))
            {
                return OperationResult<Book>.Failure("Not valid input"); //Is this if-statement really needed with my ModelState now ? 
            }

            var bookToCreate = new Book(Guid.NewGuid(), request.NewBook.Title, request.NewBook.Author, request.NewBook.Description);

            var createdBook = await _bookRepository.AddBook(bookToCreate);

            var mappedBook = _mapper.Map<Book>(createdBook);

            return OperationResult<Book>.Success(mappedBook); 
        }
    }
}
