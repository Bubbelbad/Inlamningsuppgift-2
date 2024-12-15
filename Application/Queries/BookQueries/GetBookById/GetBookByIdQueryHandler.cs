using MediatR;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Entities.Core;
using Application.Models;
using Application.Dtos.BookDtos;

namespace Application.Queries.BookQueries.GetBookById
{
    public class GetBookByIdQueryHandler(IGenericRepository<Book, Guid> repository, IMapper mapper) : IRequestHandler<GetBookByIdQuery, OperationResult<GetBookDto>>
    {
        private readonly IGenericRepository<Book, Guid> _repository = repository;
        public IMapper _mapper = mapper;

        public async Task<OperationResult<GetBookDto>> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                Book book = await _repository.GetByIdAsync(query.Id);
                if (book is null)
                {
                    return OperationResult<GetBookDto>.Failure("The book was not found in the collection");
                }

                var mappedBook = _mapper.Map<GetBookDto>(book);
                return OperationResult<GetBookDto>.Success(mappedBook, "Operation successful");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
