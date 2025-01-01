using Application.Dtos.PublisherDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.PublisherCommands.AddPublisher
{
    public class AddPublisherCommand(AddPublisherDto dto) : IRequest<OperationResult<GetPublisherDto>>
    {
        public AddPublisherDto Dto { get; set; } = dto;
    }
}
