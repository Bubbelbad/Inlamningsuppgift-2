using Application.Dtos.PublisherDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Commands.PublisherCommands.AddPublisher
{
    internal class AddPublisherCommandHandler(IGenericRepository<Publisher, int> repository, IMapper mapper) : IRequestHandler<AddPublisherCommand, OperationResult<GetPublisherDto>>
    {
        private readonly IGenericRepository<Publisher, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetPublisherDto>> Handle(AddPublisherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Publisher publisher = new()
                {
                    Name = request.Dto.Name,
                    Address = request.Dto.Address,
                    ContactInfo = request.Dto.ContactInfo
                };

                var createdPublisher = await _repository.AddAsync(publisher);
                var mappedPublisher = _mapper.Map<GetPublisherDto>(createdPublisher);
                return OperationResult<GetPublisherDto>.Success(mappedPublisher);
            }
            catch (Exception e)
            {
                return OperationResult<GetPublisherDto>.Failure(e.Message);
            }
        }
    }
}
