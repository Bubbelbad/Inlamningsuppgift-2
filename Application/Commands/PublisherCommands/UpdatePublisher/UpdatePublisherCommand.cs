using Application.Dtos.PublisherDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.PublisherCommands.UpdatePublisher
{
    public class UpdatePublisherCommand(UpdatePublisherDto dto) : IRequest<OperationResult<GetPublisherDto>>
    {
        public UpdatePublisherDto Dto { get; set; } = dto;
    }
}
