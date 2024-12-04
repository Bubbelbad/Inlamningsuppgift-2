using MediatR;
using Domain.Model;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;

namespace Application.Queries.BookQueries
{
    public class GetBookByIdQueryHandler(IBookRepository repository) : IRequestHandler<GetBookByIdQuery, OperationResult<Book>>
    {
        private readonly IBookRepository _bookRepository = repository;
        public IMapper _mapper { get; }

        public async Task<OperationResult<Book>> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
        {
            if (query.Id.Equals(Guid.Empty))
            {
                return OperationResult<Book>.Failure("The book Id was an empty Guid"); 
            }

            try
            {
                var book = await _bookRepository.GetBookById(query.Id);

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
