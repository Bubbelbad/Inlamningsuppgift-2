
using Application.Dtos.ReservationDtos;
using Application.Models;
using MediatR;

namespace Application.Commands.ReservationCommands.UpdateReservation
{
    public class UpdateReservationCommand(UpdateReservationDto dto) : IRequest<OperationResult<GetReservationDto>>
    {
        public UpdateReservationDto Dto { get; set; } = dto;
    }
}
