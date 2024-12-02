using MediatR;
using Domain.Model;
using Application.Interfaces.RepositoryInterfaces;

namespace Application.Queries.AuthorQueries
{
    public class GetAuthorByIdQueryHandler(IAuthorRepository authorRepository) : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;


        public async Task<Author> Handle(GetAuthorByIdQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query), "Query can not be null");
            }

            try
            {
                Author wantedAuthor = await _authorRepository.GetAuthorById(query.Id);
                return wantedAuthor;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
