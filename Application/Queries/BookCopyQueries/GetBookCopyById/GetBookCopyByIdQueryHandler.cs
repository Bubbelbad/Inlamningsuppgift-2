using Application.Dtos.BookCopyDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using Application.Queries.BookQueries.GetBookCopyById;
using AutoMapper;
using Domain.Entities.Locations;
using MediatR;

namespace Application.Queries.BookCopyQueries.GetBookCopyById
{
    internal class GetBookCopyByIdQueryHandler(IGenericRepository<BookCopy, Guid> repository, IMapper mapper) : IRequestHandler<GetBookCopyByIdQuery, OperationResult<GetBookCopyDto>>
    {
        private readonly IGenericRepository<BookCopy, Guid> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetBookCopyDto>> Handle(GetBookCopyByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                BookCopy book = await _repository.GetByIdAsync(request.Id);
                if (book is null)
                {
                    return OperationResult<GetBookCopyDto>.Failure("The book was not found in the collection");
                }

                var mappedBook = _mapper.Map<GetBookCopyDto>(book);
                return OperationResult<GetBookCopyDto>.Success(mappedBook, "Operation successful");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
