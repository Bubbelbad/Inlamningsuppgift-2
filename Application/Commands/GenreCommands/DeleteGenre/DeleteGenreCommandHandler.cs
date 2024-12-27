
using Application.Dtos.GenreDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Commands.GenreCommands.DeleteGenre
{
    public class DeleteGenreCommandHandler(IGenericRepository<Genre, int> repository) : IRequestHandler<DeleteGenreCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<Genre, int> _repository = repository;

        public async Task<OperationResult<bool>> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool successfulDeletion = await _repository.DeleteAsync(request.Id);
                if (successfulDeletion is false)
                {
                    return OperationResult<bool>.Failure("Genre not found");
                }

                return OperationResult<bool>.Success(successfulDeletion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
