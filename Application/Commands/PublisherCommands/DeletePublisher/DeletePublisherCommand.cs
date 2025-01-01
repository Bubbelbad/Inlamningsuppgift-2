using Application.Dtos.PublisherDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.PublisherCommands.DeletePublisher
{
    public class DeletePublisherCommand(int id) : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; } = id;
    }
}
