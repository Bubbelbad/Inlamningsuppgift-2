using Application.Dtos.PublisherDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Commands.PublisherCommands.UpdatePublisher
{
    internal class UpdatePublisherCommandHandler(IGenericRepository<Publisher, int> repository, IMapper mapper) : IRequestHandler<UpdatePublisherCommand, OperationResult<GetPublisherDto>>
    {
        private readonly IGenericRepository<Publisher, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetPublisherDto>> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var publisher = await _repository.GetByIdAsync(request.Dto.PublisherId);
                if (publisher is null)
                {
                    return OperationResult<GetPublisherDto>.Failure("Publisher not found");
                }


                publisher.Name = request.Dto.Name;
                publisher.Address = request.Dto.Address;
                publisher.ContactInfo = request.Dto.ContactInfo;

                var updatedPublisher = await _repository.UpdateAsync(publisher);
                var mappedPublisher = _mapper.Map<GetPublisherDto>(updatedPublisher);
                return OperationResult<GetPublisherDto>.Success(mappedPublisher);
            }
            catch (Exception e)
            {
                return OperationResult<GetPublisherDto>.Failure(e.Message);
            }
        }
    }
}
