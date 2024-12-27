using Application.Dtos.GenreDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Queries.GenreQueries.GetAllGenres
{
    internal class GetAllGenresQueryHandler(IGenericRepository<Genre, int> repository, IMapper mapper) : IRequestHandler<GetAllGenresQuery, OperationResult<List<GetGenreDto>>>
    {
        private readonly IGenericRepository<Genre, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<List<GetGenreDto>>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allGenres = await _repository.GetAllAsync();
                if (allGenres is null)
                {
                    return OperationResult<List<GetGenreDto>>.Failure("Operation failed");
                }

                var mappedGenres = _mapper.Map<List<GetGenreDto>>(allGenres);
                return OperationResult<List<GetGenreDto>>.Success(mappedGenres);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
