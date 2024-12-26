using Application.Dtos.GenreDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Commands.GenreCommands.UpdateGenre
{
    public class UpdateGenreCommandHandler(IGenericRepository<Genre, int> repository, IMapper mapper) : IRequestHandler<UpdateGenreCommand, OperationResult<GetGenreDto>>
    {
        private readonly IGenericRepository<Genre, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetGenreDto>> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Genre genreToUpdate = _mapper.Map<Genre>(request.Dto);

                var updatedGenre = await _repository.UpdateAsync(genreToUpdate);
                var mappedBook = _mapper.Map<GetGenreDto>(updatedGenre);

                if (updatedGenre is null)
                {
                    return OperationResult<GetGenreDto>.Failure("Operation failed");
                }
                return OperationResult<GetGenreDto>.Success(mappedBook);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
