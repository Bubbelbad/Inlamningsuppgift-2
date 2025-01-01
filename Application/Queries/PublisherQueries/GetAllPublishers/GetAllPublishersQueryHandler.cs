
using Application.Dtos.PublisherDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Metadata;
using MediatR;

namespace Application.Queries.PublisherQueries.GetAllPublishers
{
    internal class GetAllPublishersQueryHandler(IGenericRepository<Publisher, int> repository, IMapper mapper) : IRequestHandler<GetAllPublishersQuery, OperationResult<List<GetPublisherDto>>>
    {
        private readonly IGenericRepository<Publisher, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<List<GetPublisherDto>>> Handle(GetAllPublishersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allPublishers = await _repository.GetAllAsync();
                if (allPublishers is null)
                {
                    return OperationResult<List<GetPublisherDto>>.Failure("No publishers found");
                }
                var mappedPublishers = _mapper.Map<List<GetPublisherDto>>(allPublishers);
                return OperationResult<List<GetPublisherDto>>.Success(mappedPublishers);
            }
            catch
            (Exception e)
            {
                return OperationResult<List<GetPublisherDto>>.Failure(e.Message);
            }
        }
    }
}
