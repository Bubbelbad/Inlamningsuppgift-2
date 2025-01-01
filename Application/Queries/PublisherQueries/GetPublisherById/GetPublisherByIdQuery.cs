
using Application.Dtos.PublisherDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.PublisherQueries.GetPublisherById
{
    public class GetPublisherByIdQuery(int id) : IRequest<OperationResult<GetPublisherDto>>
    {
        public int Id { get; set; } = id;
    }
}
