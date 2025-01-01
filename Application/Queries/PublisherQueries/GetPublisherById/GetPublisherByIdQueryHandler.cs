using Application.Dtos.PublisherDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Queries.PublisherQueries.GetPublisherById
{
    public class GetPublisherByIdQueryHandler(IGenericRepository<Publisher, int> repository, IMapper mapper) : IRequestHandler<GetPublisherByIdQuery, OperationResult<GetPublisherDto>>
    {
        private readonly IGenericRepository<Publisher, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetPublisherDto>> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var publisher = await _repository.GetByIdAsync(request.Id);
                if (publisher is null)
                {
                    return OperationResult<GetPublisherDto>.Failure("Publisher not found");
                }
                var mappedPublisher = _mapper.Map<GetPublisherDto>(publisher);
                return OperationResult<GetPublisherDto>.Success(mappedPublisher);
            }
            catch (Exception e)
            {
                return OperationResult<GetPublisherDto>.Failure(e.Message);
            }
        }
    }
}
