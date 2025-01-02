
using Application.Dtos.ReservationDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Transactions;
using MediatR;

namespace Application.Commands.ReservationCommands.AddReservation
{
    internal class AddReservationCommandHandler(IGenericRepository<Reservation, int> repository, IMapper mapper) : IRequestHandler<AddReservationCommand, OperationResult<GetReservationDto>>
    {
        private readonly IGenericRepository<Reservation, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetReservationDto>> Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Reservation reservation = new()
                {
                    Status = "Reserved",
                    ReservationDate = DateTime.Now,
                    CopyId = request.Dto.CopyId,
                    UserId = request.Dto.UserId
                };

                var addedReservation = await _repository.AddAsync(reservation);
                if (addedReservation is null)
                {
                    return OperationResult<GetReservationDto>.Failure("Operation failed");
                }

                var mappedReservation = _mapper.Map<GetReservationDto>(addedReservation);
                return OperationResult<GetReservationDto>.Success(mappedReservation);
            }
            catch (Exception ex)
            {
                return OperationResult<GetReservationDto>.Failure("Operation failed", ex.Message);
            }
        }
    }
}
