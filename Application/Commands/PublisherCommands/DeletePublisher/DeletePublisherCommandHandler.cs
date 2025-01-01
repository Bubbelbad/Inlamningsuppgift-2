using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Commands.PublisherCommands.DeletePublisher
{
    internal class DeletePublisherCommandHandler(IGenericRepository<Publisher, int> repository, IMapper mapper) : IRequestHandler<DeletePublisherCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<Publisher, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<bool>> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var successfulDeletion = await _repository.DeleteAsync(request.Id);
                if (!successfulDeletion)
                {
                    return OperationResult<bool>.Failure("Publisher not found");
                }
                return OperationResult<bool>.Success(true);
            }
            catch (Exception e)
            {
                return OperationResult<bool>.Failure(e.Message);

            }
        }
    }
}
