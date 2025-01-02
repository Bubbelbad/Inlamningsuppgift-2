
using Application.Dtos.ReservationDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Transactions;
using MediatR;

namespace Application.Queries.ReservationQueries.GetReservationById
{
    internal class GetReservationByIdQueryHandler(IGenericRepository<Reservation, int> repository, IMapper mapper) : IRequestHandler<GetReservationByIdQuery, OperationResult<GetReservationDto>>
    {
        private readonly IGenericRepository<Reservation, int> _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<OperationResult<GetReservationDto>> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var reservation = await _repository.GetByIdAsync(request.Id);
                if (reservation is null)
                {
                    return OperationResult<GetReservationDto>.Failure("Operation failed");
                }
                var mappedReservation = _mapper.Map<GetReservationDto>(reservation);
                return OperationResult<GetReservationDto>.Success(mappedReservation);
            }
            catch (Exception ex)
            {
                return OperationResult<GetReservationDto>.Failure(ex.Message);
            }
        }
    }
}
