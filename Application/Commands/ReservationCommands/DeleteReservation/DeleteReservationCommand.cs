using Application.Models;
using MediatR;

namespace Application.Commands.ReservationCommands.DeleteReservation
{
    public class DeleteReservationCommand(int id) : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; } = id;
    }
}
