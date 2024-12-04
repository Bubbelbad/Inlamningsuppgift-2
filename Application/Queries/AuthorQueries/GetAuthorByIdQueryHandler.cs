using MediatR;
using Domain.Model;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;

namespace Application.Queries.AuthorQueries
{
    public class GetAuthorByIdQueryHandler(IAuthorRepository repository, IMapper mapper) : IRequestHandler<GetAuthorByIdQuery, OperationResult<Author>>
    {
        private IAuthorRepository _authorRepository = repository;
        public IMapper _mapper = mapper; 

        public async Task<OperationResult<Author>> Handle(GetAuthorByIdQuery query, CancellationToken cancellationToken)
        {
            if (query.Id.Equals(Guid.Empty))
            {
                return OperationResult<Author>.Failure("Id can not be empty"); 
            }

            try
            {
                var author = await _authorRepository.GetAuthorById(query.Id);

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
