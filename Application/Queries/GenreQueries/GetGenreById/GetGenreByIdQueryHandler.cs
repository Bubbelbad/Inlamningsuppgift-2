using Application.Dtos.GenreDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Queries.GenreQueries.GetGenreById
{
    internal class GetGenreByIdQueryHandler(IGenericRepository<Genre, int> repository, IMapper mapper) : IRequestHandler<GetGenreByIdQuery, OperationResult<GetGenreDto>>
    {
        private readonly IGenericRepository<Genre, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetGenreDto>> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Genre genre = await _repository.GetByIdAsync(request.Id);
                if (genre is null)
                {
                    return OperationResult<GetGenreDto>.Failure("Operation failed");
                }

                var mappedGenre = _mapper.Map<GetGenreDto>(genre);
                return OperationResult<GetGenreDto>.Success(mappedGenre, "Operation successful");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
