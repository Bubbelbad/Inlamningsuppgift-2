using MediatR;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Entities.Core;
using Application.Models;

namespace Application.Queries.AuthorQueries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler(IGenericRepository<Author, Guid> repository, IMapper mapper) : IRequestHandler<GetAuthorByIdQuery, OperationResult<Author>>
    {
        private readonly IGenericRepository<Author, Guid> _repository = repository;
        public readonly IMapper _mapper = mapper;

        public async Task<OperationResult<Author>> Handle(GetAuthorByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var author = await _repository.GetByIdAsync(query.Id);

                if (author == null)
                {
                    return OperationResult<Author>.Failure("AuthorId not found");
                }

                var mappedAuthor = _mapper.Map<Author>(author);
                return OperationResult<Author>.Success(mappedAuthor);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
