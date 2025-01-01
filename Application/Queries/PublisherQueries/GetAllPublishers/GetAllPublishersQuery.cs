
using Application.Dtos.PublisherDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.PublisherQueries.GetAllPublishers
{
    public class GetAllPublishersQuery() : IRequest<OperationResult<List<GetPublisherDto>>>
    {
    }
}
