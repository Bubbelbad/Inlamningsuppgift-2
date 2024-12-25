using Application.Dtos.GenreDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Commands.GenreCommands.AddGenre
{
    internal class AddGenreCommandHandler(IGenericRepository<Genre, int> repository, IMapper mapper) : IRequestHandler<AddGenreCommand, OperationResult<GetGenreDto>>
    {
        private readonly IGenericRepository<Genre, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetGenreDto>> Handle(AddGenreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Genre genre = new()
                {
                    Name = request.Dto.Name,
                    Description = request.Dto.Description
                };

                var addedGenre = await _repository.AddAsync(genre);
                var mappedGenre = _mapper.Map<GetGenreDto>(addedGenre);

                return OperationResult<GetGenreDto>.Success(mappedGenre, "Operation successful");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding object to collection.", ex);
            }
        }
    }
}
