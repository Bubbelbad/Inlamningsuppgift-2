using MediatR;
using Domain.Model;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;

namespace Application.Queries.BookQueries
{
    public class GetBookByIdQueryHandler(IBookRepository repository, IMapper mapper) : IRequestHandler<GetBookByIdQuery, OperationResult<Book>>
    {
        private readonly IBookRepository _bookRepository = repository;
        public IMapper _mapper = mapper;

        public async Task<OperationResult<Book>> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
        {
            if (query.Id.Equals(Guid.Empty))
            {
                return OperationResult<Book>.Failure("The book Id was an empty Guid");
            }

            try
            {
                Book book = await _bookRepository.GetBookById(query.Id);
                if (book is null)
                {
                    return OperationResult<Book>.Failure("The book was not found in the collection");
                }

                var mappedBook = _mapper.Map<Book>(book);
                return OperationResult<Book>.Success(mappedBook, "Operation successful");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
