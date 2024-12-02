using MediatR;
using Domain.Model;
using Application.Interfaces.RepositoryInterfaces;

namespace Application.Queries.BookQueries
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<Book> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query), "Query cannot be null.");
            }

            try
            {
                Book wantedBook = await _bookRepository.GetBookById(query.Id);
                return wantedBook;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
