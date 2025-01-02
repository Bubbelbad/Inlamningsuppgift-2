using Application.Dtos.ReservationDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.ReservationCommands.AddReservation
{
    public class AddReservationCommand(AddReservationDto dto) : IRequest<OperationResult<GetReservationDto>>
    {
        public AddReservationDto Dto { get; set; } = dto;
    }
}
