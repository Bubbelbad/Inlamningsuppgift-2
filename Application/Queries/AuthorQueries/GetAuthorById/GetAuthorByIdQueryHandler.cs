using MediatR;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Entities.Core;
using Application.Models;

namespace Application.Queries.AuthorQueries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler(IAuthorRepository repository, IMapper mapper) : IRequestHandler<GetAuthorByIdQuery, OperationResult<Author>>
    {
        private readonly IAuthorRepository _authorRepository = repository;
        public readonly IMapper _mapper = mapper;

        public async Task<OperationResult<Author>> Handle(GetAuthorByIdQuery query, CancellationToken cancellationToken)
        {
            if (query.Id.Equals(Guid.Empty))
            {
                return OperationResult<Author>.Failure("Id can not be empty");
            }

            try
            {
                var author = await _authorRepository.GetAuthorById(query.Id);
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
