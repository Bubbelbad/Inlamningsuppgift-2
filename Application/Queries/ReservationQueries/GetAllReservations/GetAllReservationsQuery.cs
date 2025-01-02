
using Application.Dtos.ReservationDtos;
using Application.Models;
using MediatR;

namespace Application.Queries.ReservationQueries.GetAllReservations
{
    public class GetAllReservationsQuery() : IRequest<OperationResult<List<GetReservationDto>>>
    {

    }
}
