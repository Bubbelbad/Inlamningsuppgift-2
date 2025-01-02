
using Application.Dtos.ReservationDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Transactions;
using MediatR;

namespace Application.Queries.ReservationQueries.GetAllReservations
{
    internal class GetAllReservationsQueryHandler(IGenericRepository<Reservation, int> repository, IMapper mapper) : IRequestHandler<GetAllReservationsQuery, OperationResult<List<GetReservationDto>>>
    {
        private readonly IGenericRepository<Reservation, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<List<GetReservationDto>>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allReservations = await _repository.GetAllAsync();
                if (allReservations is null)
                {
                    return OperationResult<List<GetReservationDto>>.Failure("No reservations found");
                }
                var mappedReservations = _mapper.Map<List<GetReservationDto>>(allReservations);

                return OperationResult<List<GetReservationDto>>.Success(mappedReservations);
            }
            catch (Exception ex)
            {
                return OperationResult<List<GetReservationDto>>.Failure(ex.Message);
            }
        }
    }
}
