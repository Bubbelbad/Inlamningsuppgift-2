using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Queries.GenreQueries.GetGenreById
{
    internal class GetGenreByIdQueryHandler(IGenericRepository<Genre, int> repository) : IRequestHandler<GetGenreByIdQuery, OperationResult<Genre>>
    {
        private readonly IGenericRepository<Genre, int> _repository;

        public async Task<OperationResult<Genre>> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Genre genre = await _repository.GetByIdAsync(request.Id);
                if (genre == null)
                {
                    return OperationResult<Genre>.Failure("Operation failed");
                }
                return OperationResult<Genre>.Success(genre, "Operation successful");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
