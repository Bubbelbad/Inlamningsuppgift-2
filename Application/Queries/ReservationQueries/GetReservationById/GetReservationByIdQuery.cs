
using Application.Dtos.ReservationDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.ReservationQueries.GetReservationById
{
    public class GetReservationByIdQuery(int id) : IRequest<OperationResult<GetReservationDto>>
    {
        public int Id { get; set; } = id;
    }
}
