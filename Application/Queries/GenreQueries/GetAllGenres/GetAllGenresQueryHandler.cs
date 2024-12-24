using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Queries.GenreQueries.GetAllGenres
{
    internal class GetAllGenresQueryHandler(IGenericRepository<Genre, int> repository, IMapper mapper) : IRequestHandler<GetAllGenresQuery, OperationResult<List<Genre>>>
    {
        private readonly IGenericRepository<Genre, int> _repository;
        private readonly IMapper _mapper;

        public async Task<OperationResult<List<Genre>>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allGenres = await _repository.GetAllAsync();
                var mappedGenres = _mapper.Map<List<Genre>>(allGenres);

                return OperationResult<List<Genre>>.Success(mappedGenres);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
